using System;
using LCore.Tools;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Dynamic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods dealing with the C# language and code
    /// </summary>
    public static class LanguageExt
        {
        #region FindSourceCode

        /// <summary>
        /// Retrieves a block of code for a member.
        /// Optionally, include code comments and any member Attributes
        /// </summary>
        [CanBeNull]
        public static string FindSourceCode([CanBeNull] this MemberInfo Member, bool IncludeAttributes = false,
            bool IncludeComments = false)
            {
            if (Member == null)
                return null;

            var RootClass = Member is Type ? (Type)Member : Member.DeclaringType;

            while (RootClass?.DeclaringType != null)
                RootClass = RootClass.DeclaringType;

            string CodeLocation = RootClass.FindClassFile(); //CodeExploder.CodeRootLocation;

            if (!string.IsNullOrEmpty(CodeLocation))
                {
                string[] CodeLines = File.ReadAllLines(CodeLocation);

                string SearchStr = $"{Member.GetMemberType().GetGenericName()} {Member.Name}";
                string SearchStr_Native = L._Lang.ReplaceNativeTypes(SearchStr);

                string SearchStr2 = "", SearchStr3 = "", SearchStr4 = "";
                string SearchStr2_Native = "", SearchStr3_Native = "", SearchStr4_Native = "";

                if (Member is Type)
                    {
                    var Details = ((Type)Member).GetMemberDetails();
                    SearchStr = Details?.ToCodeString().ToLower() + " " + ((Type)Member).Name;
                    SearchStr_Native = L._Lang.ReplaceNativeTypes(SearchStr);

                    SearchStr = $"{SearchStr}";
                    SearchStr_Native = $"{SearchStr_Native}";
                    SearchStr2 = $"{SearchStr} : ";
                    SearchStr2_Native = $"{SearchStr_Native} : ";
                    }
                if (Member is MethodInfo)
                    {
                    SearchStr = $"{SearchStr}(";
                    SearchStr_Native = $"{SearchStr_Native}(";
                    SearchStr2 = $"{SearchStr}";
                    SearchStr2_Native = $"{SearchStr_Native}";
                    }
                if (Member is PropertyInfo)
                    {
                    SearchStr3 = $"{SearchStr} ";
                    SearchStr3_Native = $"{SearchStr_Native} ";
                    }
                if (Member is PropertyInfo)
                    {
                    SearchStr4 = $"{SearchStr}\r\n";
                    SearchStr4_Native = $"{SearchStr_Native}\r\n";
                    }

                int? Index =
                    CodeLines.IndexOf(Line => SearchStr4_Native != "" && Line.Contains(SearchStr4_Native)) ??
                    CodeLines.IndexOf(Line => SearchStr4 != "" && Line.Contains(SearchStr4)) ??
                    CodeLines.IndexOf(Line => SearchStr3_Native != "" && Line.Contains(SearchStr3_Native)) ??
                    CodeLines.IndexOf(Line => SearchStr3 != "" && Line.Contains(SearchStr3)) ??
                    CodeLines.IndexOf(Line => SearchStr2_Native != "" && Line.Contains(SearchStr2_Native)) ??
                    CodeLines.IndexOf(Line => SearchStr2 != "" && Line.Contains(SearchStr2)) ??
                    CodeLines.IndexOf(Line => SearchStr != "" && Line.Contains(SearchStr)) ??
                    CodeLines.IndexOf(Line => SearchStr_Native != "" && Line.Contains(SearchStr_Native));

                var AttributeIndices = new List<int>();

                if (Index != null)
                    {
                    string StartBraceLine = CodeLines[(int)Index + 1];
                    string EndBraceLine = StartBraceLine.Replace("{", "}");

                    int StartIndex = (int)Index;
                    int EndIndex = (int)Index + 1;

                    bool SingleLineMember = CodeLines[StartIndex].Trim().EndsWith("{}") ||
                                            CodeLines[StartIndex].Trim().EndsWith("{ }") ||
                                            (Member is PropertyInfo &&
                                             CodeLines[StartIndex].Contains($"{SearchStr} => ")) ||
                                            (Member is PropertyInfo &&
                                             CodeLines[StartIndex].Contains($"{SearchStr2} => "));

                    if (SingleLineMember)
                        EndIndex = (int)Index;

                    while (StartIndex > 0)
                        {
                        StartIndex--;

                        string Line = CodeLines[StartIndex].Trim();

                        // TODO Add support for split-line attributes 
                        if ((IncludeAttributes || IncludeComments) && Line.StartsWith("[") && Line.EndsWith("]"))
                            {
                            AttributeIndices.Add(StartIndex);
                            continue;
                            }
                        if (IncludeComments &&
                            (Line.Trim().StartsWith("//") ||
                             Line.Trim().StartsWith("*/") ||
                             Line.Trim().StartsWith("*") ||
                             Line.Trim().StartsWith("/*")))
                            continue;

                        StartIndex++;
                        break;
                        }

                    while (!SingleLineMember && EndIndex < CodeLines.Length - 1)
                        {
                        EndIndex++;

                        string Line = CodeLines[EndIndex];

                        if (!Line.StartsWith(EndBraceLine) && Line != EndBraceLine)
                            continue;

                        break;
                        }

                    if (EndIndex != CodeLines.Length - 1)
                        {
                        return CodeLines.Select(
                                (i, Line) => i >= StartIndex && i <= EndIndex &&
                                             // Filter to return comments but not attributes
                                             !(IncludeComments && !IncludeAttributes && AttributeIndices.Has(i)))
                            .JoinLines();
                        }
                    }
                }
            return null;
            }

        #endregion

        #region FindSourceCodeLineNumber

        /// <summary>
        /// Determines the starting line of code for the given member,
        /// if source code is available.
        /// 
        /// The line number returned is 1-based NOT 0-based.
        /// </summary>
        [CanBeNull]
        public static uint? FindSourceCodeLineNumber([CanBeNull] this MemberInfo Member)
            {
            if (Member == null)
                return null;

            string CodeLocation = Member.DeclaringType.FindClassFile(); //CodeExploder.CodeRootLocation;

            if (!string.IsNullOrEmpty(CodeLocation))
                {
                string[] CodeLines = File.ReadAllLines(CodeLocation);

                string SearchStr = $"{Member.GetMemberType().GetGenericName()} {Member.Name}";
                string SearchStr2 = L._Lang.ReplaceNativeTypes(SearchStr);

                int? Index = CodeLines.IndexOf(Line => Line.Contains(SearchStr)) ??
                             CodeLines.IndexOf(Line => Line.Contains(SearchStr2));

                if (Index != null)
                    return (uint)(int)(Index
                                         + 1); // Line index returned is 1-based not 0-based
                }
            return null;
            }

        #endregion

        #region FindSourceCodeLineCount

        /// <summary>
        /// Determines the number of lines in a block of code, if source is available.
        /// By default, Attributes and comments are included, but empty lines are not.
        /// </summary>
        [CanBeNull]
        public static uint? FindSourceCodeLineCount([CanBeNull] this MemberInfo Member,
            bool IncludeEmptyLines = false,
            bool IncludeAttributes = true,
            bool IncludeComments = true)
            {
            string[] Source = Member.FindSourceCode(IncludeAttributes, IncludeComments).Lines();

            uint Out = Source.Count(Line =>
                {
                    string Line2 = Line.Trim();

                    return IncludeEmptyLines || (Line2 != "}" && Line2 != "{" && Line2 != "");
                });

            return Out == 0u
                ? null
                : (uint?)Out;
            }

        #endregion

        /// <summary>
        /// Gathers code metadata for a <paramref name="Member"/> if it's available.
        /// </summary>
        [CanBeNull]
        public static CodeMetaData GatherSourceCodeMetaData([CanBeNull] this MemberInfo Member)
            {
            return Member == null
                ? null
                : new CodeMetaData(Member);
            }

        /// <summary>
        /// Retrieves a member's declaration details
        /// </summary>
        [CanBeNull]
        public static MemberDetails GetMemberDetails(this MemberInfo Member)
            {
            if (Member is MethodInfo)
                {
                var Method = (MethodInfo)Member;

                return new MemberDetails
                    {
                    Context = Method.IsStatic
                        ? MemberContext.Static
                        : MemberContext.Instance,
                    Type = MemberType.Method,
                    Inheritance =
                        Method.IsAbstract
                            ? MemberInheritance.Abstract
                            : Method.IsOverride()
                                ? MemberInheritance.Override
                                : Method.IsVirtual
                                    ? MemberInheritance.Virtual
                                    : Method.IsSealed()
                                        ? MemberInheritance.Sealed
                                        : MemberInheritance.None,
                    Scope =
                        Method.IsPublic
                            ? MemberScope.Public
                            : Method.IsInternal()
                                ? MemberScope.Internal
                                : Method.IsProtected()
                                    ? MemberScope.Protected
                                    : MemberScope.Private
                    };
                }
            if (Member is Type)
                {
                var Type = (Type)Member;

                return new MemberDetails
                    {
                    Context = Type.IsStatic()
                        ? MemberContext.Static
                        : MemberContext.Instance,
                    Type = Type.IsEnum
                        ? MemberType.Enum
                        : Type.IsClass
                            ? MemberType.Class
                            : Type.IsInterface
                                ? MemberType.Interface
                                : MemberType.Structure,
                    Inheritance =
                        Type.IsAbstract
                            ? MemberInheritance.Abstract
                            : Type.IsSealed
                                ? MemberInheritance.Sealed
                                : MemberInheritance.None,
                    Scope = Type.IsInternal()
                        ? MemberScope.Internal
                        : Type.IsProtected()
                            ? MemberScope.Protected
                            : MemberScope.Public
                    };
                }

            // TODO property types
            // TODO field types
            // TODO event types

            return null;
            }
        }

    public static partial class L
        {
        [ExcludeFromCodeCoverage]
        // ReSharper disable once InconsistentNaming
        internal static class _Lang
            {
            public static readonly string[] GenericInputTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16" };
            public static readonly string[] GenericOutputTypes = { "U" };
            public static readonly string[] GenericTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16", "U" };
            public static readonly string[] OpenSequences = { "[", "{", "(", "<", "\'", "\"", "/*", "//" };
            public static readonly string[] CloseSequences = { "]", "}", ")", ">", "\'", "\"", "*/", "\r\n" };
            public static readonly char[] SeparatorChars = { ' ', ',', '<', '>', '(', ')', '{', '}', '[', ']', '-', '+', '.', '/', '*', '-', '&', '^', '%', '=', '?' };

            #region LanguageGetCodeString

            public static string LanguageGetCodeString(string File)
                {
                Func<string, string> Function = F<string, string>(
                        FileName => L.File.GetFileContents(FileName).ByteArrayToString())
                    .Cache(nameof(LanguageGetCodeString));

                return Function(File);
                }

            #endregion

            #region LanguageGetCodeFiles

            public static readonly Func<string, List<FileInfo>> LanguageGetCodeFiles = F<string, List<FileInfo>>(Str =>
                {
                    return Directory.GetFiles(Str, $"*{CodeExplode.ExplodeFileType}", SearchOption.AllDirectories).List().Select(
                            Str2 => !Str2.ToLower().Contains(CodeExploder.CodeExplodeLocation?.ToLower() ?? "#"))
                        .Convert(Str3 => new FileInfo(Str3));
                }).Cache("CodeExplode_FileInfoCache");

            #endregion

            #region MemberInfoGetCodeFromPath

            public static readonly Func<string, MemberInfo, string> MemberInfoGetCodeFromPath = (Path, Member) =>
                {
                    List<FileInfo> Files = LanguageGetCodeFiles(Path);
                    string SearchStr = $"{CleanGenericTypeName(Member?.GetMemberType()?.ToString())} {Member?.Name}";
                    string SearchStr2 = ReplaceNativeTypes(SearchStr);
                    string SearchStr3 = Member?.Name + CodeExplodeGenerics.MethodActionToken;
                    string SearchStr4 = Member?.Name + CodeExplodeGenerics.MethodFuncToken;
                    SearchStr = SearchStr.Replace(",", ", ");
                    string Code = "";
                    int Index = -1;

                    var File = Files.First(FileInfo =>
                        {
                            string FileContents = LanguageGetCodeString(FileInfo.FullName);

                            if (FileContents.Contains(SearchStr4))
                                {
                                SearchStr = SearchStr4;
                                Code = FileContents;
                                Index = Code.IndexOf(SearchStr);
                                return true;
                                }
                            if (FileContents.Contains(SearchStr3))
                                {
                                SearchStr = SearchStr3;
                                Code = FileContents;
                                Index = Code.IndexOf(SearchStr);
                                return true;
                                }
                            if (FileContents.Contains(SearchStr2))
                                {
                                SearchStr = SearchStr2;
                                Code = FileContents;
                                Index = Code.IndexOf(SearchStr);
                                return true;
                                }
                            if (FileContents.Contains(SearchStr))
                                {
                                Code = FileContents;
                                Index = Code.IndexOf(SearchStr);
                                return true;
                                }
                            return false;
                        });
                    if (File == null)
                        {
                        return "";
                        }
                    string Temp = Code.Sub(Start: 0, Length: Index);
                    Index = Temp.LastIndexOf("\r\n", StringComparison.Ordinal);
                    Code = Code.Substring(Index + 2);
                    int OpenBraceIndex = Code.IndexOf(value: '{');
                    int EndIndex = LanguageFindMate(Code, OpenBraceIndex) + 1;

                    string Out = $"{Code.Sub(Start: 0, Length: EndIndex)}\r\n";

                    if (Out.IsEmpty())
                        {
                        }
                    return Out;
                };

            #endregion

            #region LanguageFindMate

            public static readonly Func<string, int, int> LanguageFindMate = (Str, Start) =>
                {
                    char Open = Str[Start];
                    char Close = CloseSequences[OpenSequences.List().IndexOf(Str[Start].ToString())][index: 0];
                    int Depth = 0;
                    int Index = Start + 1;
                    int Out = -1;
                    Index.For(Str.Length - 1, i =>
                        {
                            if (Str[i] == Open)
                                Depth++;
                            if (Str[i] == Close)
                                {
                                if (Depth == 0)
                                    {
                                    Out = i;
                                    return false;
                                    }
                                Depth--;
                                }
                            return true;
                        });

                    return Out;
                };

            #endregion

            #region RemoveTypeNamespaces

            internal static readonly Func<string, string> RemoveTypeNamespaces = Str =>
                {
                    while (Str.Has(Obj: '.'))
                        {
                        int Index = Str.IndexOf(value: '.');
                        string Temp = Str.Sub(Start: 0, Length: Index);
                        int IndexSpace = Temp.LastIndexOfAny(SeparatorChars);
                        if (IndexSpace < 0)
                            {
                            Str = Str.Sub(Index + 1);
                            }
                        else
                            {
                            Str = Str.Sub(Start: 0, Length: IndexSpace + 1) + Str.Substring(Index + 1);
                            }
                        }
                    return Str;
                };

            #endregion

            #region CleanGenericTypeName

            internal static readonly Func<string, string> CleanGenericTypeName = Str =>
                {
                    Str = Str.Replace("`1[", "<");
                    Str = Str.Replace("`2[", "<");
                    Str = Str.Replace("`3[", "<");
                    Str = Str.Replace("`4[", "<");
                    Str = Str.Replace("`5[", "<");
                    Str = Str.Replace("`6[", "<");
                    Str = Str.Replace("`7[", "<");
                    Str = Str.Replace("`8[", "<");
                    Str = Str.Replace("`9[", "<");
                    Str = Str.Replace("`10[", "<");
                    Str = Str.Replace("`11[", "<");
                    Str = Str.Replace("`12[", "<");
                    Str = Str.Replace("`13[", "<");
                    Str = Str.Replace("`14[", "<");
                    Str = Str.Replace("`15[", "<");
                    Str = Str.Replace("`16[", "<");
                    Str = Str.Replace("`17[", "<");
                    Str = Str.Replace("Action`10", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>");
                    Str = Str.Replace("Action`11", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>");
                    Str = Str.Replace("Action`12", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>");
                    Str = Str.Replace("Action`13", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>");
                    Str = Str.Replace("Action`14", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>");
                    Str = Str.Replace("Action`15", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>");
                    Str = Str.Replace("Action`16", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>");
                    Str = Str.Replace("Action`1", "Action<T1>");
                    Str = Str.Replace("Action`2", "Action<T1,T2>");
                    Str = Str.Replace("Action`3", "Action<T1,T2,T3>");
                    Str = Str.Replace("Action`4", "Action<T1,T2,T3,T4>");
                    Str = Str.Replace("Action`5", "Action<T1,T2,T3,T4,T5>");
                    Str = Str.Replace("Action`6", "Action<T1,T2,T3,T4,T5,T6>");
                    Str = Str.Replace("Action`7", "Action<T1,T2,T3,T4,T5,T6,T7>");
                    Str = Str.Replace("Action`8", "Action<T1,T2,T3,T4,T5,T6,T7,T8>");
                    Str = Str.Replace("Action`9", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9>");
                    Str = Str.Replace("Func`10", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,U>");
                    Str = Str.Replace("Func`11", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,U>");
                    Str = Str.Replace("Func`12", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,U>");
                    Str = Str.Replace("Func`13", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,U>");
                    Str = Str.Replace("Func`14", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,U>");
                    Str = Str.Replace("Func`15", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,U>");
                    Str = Str.Replace("Func`16", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,U>");
                    Str = Str.Replace("Func`17", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,U>");
                    Str = Str.Replace("Func`1", "Func<U>");
                    Str = Str.Replace("Func`2", "Func<T1,U>");
                    Str = Str.Replace("Func`3", "Func<T1,T2,U>");
                    Str = Str.Replace("Func`4", "Func<T1,T2,T3,U>");
                    Str = Str.Replace("Func`5", "Func<T1,T2,T3,T4,U>");
                    Str = Str.Replace("Func`6", "Func<T1,T2,T3,T4,T5,U>");
                    Str = Str.Replace("Func`7", "Func<T1,T2,T3,T4,T5,T6,U>");
                    Str = Str.Replace("Func`8", "Func<T1,T2,T3,T4,T5,T6,T7,U>");
                    Str = Str.Replace("Func`9", "Func<T1,T2,T3,T4,T5,T6,T7,T8,U>");
                    Str = Str.Replace("[]", "***");
                    Str = Str.Replace("]", ">");
                    Str = Str.Replace("[", ">");
                    Str = Str.Replace("***", "[]");
                    return RemoveTypeNamespaces(Str);
                };

            #endregion

            #region GetAssemblyTypesWithAttribute

            internal static readonly Func<Type, List<Type>> GetAssemblyTypesWithAttribute = Attr =>
                {
                    return Assembly.GetCallingAssembly().GetModules()
                        .Convert(Module => { return Module.GetTypes().Select(Type => { return Attr.TypeEquals(typeof(void)) || Type.HasAttribute(Attr, IncludeBaseClasses: true); }); })
                        .Flatten<Type>();
                };

            #endregion

            #region GetAssemblyTypes

            internal static Func<List<Type>> GetAssemblyTypes = GetAssemblyTypesWithAttribute.Supply(typeof(void));

            #endregion

            #region ReplaceNativeTypes

            internal static readonly Func<string, string> ReplaceNativeTypes = Str =>
                {
                    Str = Str.Replace("Double", "double");
                    Str = Str.Replace("UInt64", "ulong");
                    Str = Str.Replace("Int64", "long");
                    Str = Str.Replace("UInt32", "uint");
                    Str = Str.Replace("Int32", "int");
                    Str = Str.Replace("Single", "float");
                    Str = Str.Replace("Boolean", "bool");
                    Str = Str.Replace("String", "string");
                    return Str;
                };

            #endregion

            #region CommentSummary

            internal static readonly Func<string, string> CommentSummary =
                In => In.Replace("\r\n", "\r\n/// ").Surround("/// <summary>\r\n/// ", "\r\n/// </summary>\r\n");

            #endregion

            #region Class

            internal static readonly Func<string, string, bool, string> Class =
                (In, ClassName, Static) => In.Surround(
                    $"public {(Static ? "static " : "")}class {ClassName}\r\n{{\r\n", "}\r\n");

            #endregion

            #region Using

            internal static readonly Func<string[], string, string> Using = (Using, In) =>
                {
                    if (Using.IsEmpty() || In.IsEmpty())
                        return In;

                    string Out = "";
                    Using.Each(Str => { Out += $"using {Str};\r\n"; });
                    Out += "\r\n";
                    Out += In;
                    return Out;
                };

            #endregion

            #region Namespace

            internal static readonly Func<string, string, string> Namespace = (In, NamespaceName) => In.Surround(
                $"namespace {NamespaceName}\r\n{{\r\n",
                "}\r\n");

            #endregion

            #region Region

            internal static readonly Func<string, string, string> Region = (In, Region) => In.Surround(
                $"#region {Region}\r\n",
                "#endregion\r\n");

            #endregion

            #region GetGenericsFromTypes

            internal static readonly Func<string[], List<string>> GetGenericsFromTypes = Generics =>
                {
                    var Out = new List<string>();
                    Generics.Each(Generic => { Out.AddRange(GetTypeGenerics(Generic)); });

                    Out = Out.RemoveDuplicates();
                    Out = Out.Select(Str => GenericTypes.Has(Str)).List();
                    Out.Sort(Str.NumericalCompare);
                    return Out;
                };

            #endregion

            #region GetTypeGenerics

            internal static readonly Func<string, List<string>> GetTypeGenerics = TypeStr =>
                {
                    string Out = TypeStr.Has(Obj: '<')
                        ? TypeStr.Sub(TypeStr.LastIndexOf(value: '<') + 1, TypeStr.LastIndexOf(value: '>') - TypeStr.LastIndexOf(value: '<') - 1)
                        : "";
                    if (Out.Has(Obj: ','))
                        return Out.Split(',').List().Collect(Str =>
                            {
                                if (Str == "T")
                                    return "T1";
                                return Str == ""
                                ? null
                                : Str.Trim();
                            });
                    return !Out.IsEmpty()
                        ? new List<string> { Out }
                        : new List<string>();
                };

            #endregion

            #region GetEmptyTypeLambdaMethods

            internal static Func<Type, string> GetEmptyTypeLambdaMethods = Type =>
                {
                    MethodInfo[] Methods = Type.GetMethods();
                    return Methods.Convert(GetEmptyLambdaFromMethod).Combine();
                };

            #endregion

            #region GetEmptyLambdaFromMethod

            internal static readonly Func<MethodInfo, string> GetEmptyLambdaFromMethod = Method =>
                {
                    string FunctionTypeName = CleanGenericTypeName(Method.ReturnType.ToString());
                    string ParameterTypes = Method.GetParameters().Convert(Param => CleanGenericTypeName(Param.ParameterType.ToString())).Combine(", ");
                    string ParameterNames = Method.GetParameters().Convert(Param => Param.Name).Combine(",  ");
                    List<string> Generics = GetGenericsFromTypes(ParameterTypes.Split(",  ").Add(FunctionTypeName));
                    bool ReadOnly = Generics.IsEmpty();
                    string BaseType = Method.ReturnType.TypeEquals(typeof(void))
                        ? "Action"
                        : "Func";
                    if (!ParameterTypes.IsEmpty())
                        BaseType += $"<{ParameterTypes}";
                    if (!Method.ReturnType.TypeEquals(typeof(void)))
                        BaseType += $", {CleanGenericTypeName(Method.ReturnType.ToString())}";
                    BaseType += ">";

                    string Out = $"public static {(ReadOnly ? "readonly " : "")}";
                    Out += $"{BaseType} ";
                    Out += Method.Name;
                    if (!ReadOnly)
                        {
                        Out += $"<{Generics.Combine(", ")}>";
                        Out += "()\r\n";
                        Out += "{\r\n";
                        Out += "return ";
                        }
                    else
                        {
                        Out += " = ";
                        }
                    Out += $"({ParameterNames}) => \r\n";
                    Out += "{\r\n";
                    Out += "};\r\n";
                    if (!ReadOnly)
                        {
                        Out += "}\r\n";
                        }

                    if (Out.Contains(", )"))
                        {
                        }

                    return Out;
                };

            #endregion

            #region GetExtensionMethodDeclaration

            internal static readonly Func<string, Lists<string, Type>, Type, string, MemberTypes, bool, string> GetExtensionMethodDeclaration = (Name, Params, OutType, Comment, MemberType, ExecuteResult) =>
                {
                    if (Params.List1.Count == 0 ||
                        Params.List2.Count == 0)
                        throw new ArgumentException("No Parameters found");
                    string FunctionTypeName = CleanGenericTypeName(OutType.ToString());
                    string ExtensionParam = CleanGenericTypeName(Params.List2[index: 0].ToString());
                    string Parameters = "";
                    if (Params.Count > 1)
                        Parameters = 1.To(Params.Count - 1, i => { return CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

                    List<string> Generics = GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

                    string Out = $"public static {(ExecuteResult ? "void " : FunctionTypeName)}";
                    Out += $" {Name}";


                    if (!Generics.IsEmpty())
                        {
                        Out += $"<{Generics.Combine(", ")}>";
                        }

                    Out += $"(this {ExtensionParam} {Params.List1[index: 0]}";
                    if (Params.Count > 1)
                        {
                        Out += ", ";
                        1.For(Params.Count, i =>
                            {
                                string ParamType = CleanGenericTypeName(Params.List2[i].ToString());
                                if (Params.List1[i].StartsWith("params"))
                                    {
                                    Out += "params ";
                                    Params.Set1(i, Params.List1[i].Substring(startIndex: 7));
                                    }
                                Out += $"{ParamType} {Params.List1[i]}";
                                if (i < Params.Count - 1)
                                    Out += ", ";
                                return true;
                            });
                        }

                    Out += ")\r\n";

                    if (Out.Contains(", )"))
                        {
                        }

                    if (!Comment.IsEmpty())
                        Out = CommentSummary(Comment) + Out;
                    return Out;
                };

            #endregion

            #region GetExtensionMethodBody

            internal static readonly Func<Type, string, Lists<string, Type>, Type, MemberTypes, bool, string> GetExtensionMethodBody = (DeclaringType, Name, Params, ReturnType, MemberType, ExecuteResult) =>
                {
                    string ExtensionParam = CleanGenericTypeName(Params.List2[index: 0].ToString());
                    string Parameters = "";
                    if (Params.Count > 1)
                        Parameters = 1.To(Params.Count - 1, i => { return CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

                    string FunctionTypeName = CleanGenericTypeName(ReturnType.ToString());
                    List<string> Generics = GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

                    string Out = "{\r\n";
                    Out +=
                        $"{(!ReturnType.TypeEquals(typeof(void)) && !ExecuteResult ? "return " : "")}{DeclaringType.Name}.{Name}";

                    if (!Generics.IsEmpty())
                        {
                        Out += $"<{Generics.Combine(", ")}>";
                        }

                    Out +=
                        $"{(MemberType.HasFlag(MemberTypes.Method) ? "()" : "")}({Params.List1.List().Collect(Str => { if (Str.Contains(" = ")) Str = Str.Sub(Start: 0, Length: Str.IndexOf(" = ")); return Str; }).Combine(", ")})";
                    if (ExecuteResult)
                        Out += "()";
                    Out += ";\r\n";

                    Out += "}\r\n";
                    return Out;
                };

            #endregion
            }
        }
    }