using System;

using LCore.Extensions;
using LCore.Dynamic;
using LCore.Tools;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using JetBrains.Annotations;

#pragma warning disable 1591

namespace LCore.Extensions
    {
    public static partial class L
        {
        internal static class Exploder
            {
            #region LogicTypeToExtensionStrings
            public static Func<Type, string> LogicTypeToExtensionStrings = Type =>
            {
                List<MemberInfo> Members = Type.GetMembers().Select(
                    Member => (Member is FieldInfo && ((FieldInfo)Member).IsStatic)
                        || (Member is MethodInfo && ((MethodInfo)Member).IsStatic)).List();
                List<string> MemberNames = Members.Convert(Member => Member.Name);
                var Members2 = new Lists<string, MemberInfo>(MemberNames, Members);

                return LogicMemberInfoToExtensionStrings(Members2, "", null);
            };
            #endregion
            #region LogicMemberInfoExplode
            public static readonly Func<Lists<string, MemberInfo>, string> LogicMemberInfoExplode =
                Members => Members.List2.Convert(MemberInfoExplode).Combine("\r\n");
            #endregion
            #region MemberInfoGetCode
            public static readonly Func<MemberInfo, string> MemberInfoGetCode = Member =>
                {
                    string CodeLocation = CodeExploder.CodeRootLocation;
                    if (CodeLocation.IsEmpty())
                        throw new Exception("CodeExploder.CodeRootLocation has not been set");
                    return MemberInfoGetCodeFromPath(CodeLocation, Member);
                };
            #endregion
            #region MemberInfoGetCodeFromPath
            public static readonly Func<string, MemberInfo, string> MemberInfoGetCodeFromPath = (Path, Member) =>
                {
                    List<FileInfo> Files = LanguageGetCodeFiles(Path);
                    string SearchStr = $"{Lang.CleanGenericTypeName(Member.GetMemberType().ToString())} {Member.Name}";
                    string SearchStr2 = Lang.ReplaceNativeTypes(SearchStr);
                    string SearchStr3 = Member.Name + CodeExplodeGenerics.MethodActionToken;
                    string SearchStr4 = Member.Name + CodeExplodeGenerics.MethodFuncToken;
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
                    string Temp = Code.Sub(0, Index);
                    Index = Temp.LastIndexOf("\r\n", StringComparison.Ordinal);
                    Code = Code.Substring(Index + 2);
                    int OpenBraceIndex = Code.IndexOf('{');
                    int EndIndex = LanguageFindMate(Code, OpenBraceIndex) + 1;

                    string Out = $"{Code.Sub(0, EndIndex)}\r\n";

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
                char Close = Lang.CloseSequences[Lang.OpenSequences.List().IndexOf(Str[Start].ToString())][0];
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
            #region LanguageGetCodeString
            public static readonly Func<string, string> LanguageGetCodeString = F<string, string>(
                File => L.File.GetFileContents(File).ByteArrayToString()).Cache("Language_GetCodeString");
            #endregion
            #region MemberInfoExplode
            public static readonly Func<MemberInfo, string> MemberInfoExplode = Member =>
            {
                var Replacements = new List<List<string>>();
                string Comments = "";
                if (Member.HasAttribute(typeof(CodeExplodeGenerics), true))
                    {
                    var Attr = Member.GetAttribute<CodeExplodeGenerics>();
                    // ReSharper disable once InvocationIsSkipped
                    Debug.Assert(Attr != null, "Attr != null");
                    // ReSharper disable once PossibleNullReferenceException
                    Comments = Attr.Comments;
                    if (!Attr.Replacements.IsEmpty())
                        {
                        Replacements.AddRange(Attr.Replacements);
                        }
                    }
                string Out = "";
                string MethodCode = MemberInfoGetCode(Member);
                string FunctionNameSearch = $" {Member.Name}";
                bool Level2_Tokens = CodeExplodeGenerics.ContainsMultiLevelTokens(MethodCode);

                if (Level2_Tokens)
                    {
                    List<List<string>> Replacements2 = CodeExplodeGenerics.GetLevel2Replacements();
                    List<string> TempBase = CodeExplode(Member, MethodCode, Replacements2, FunctionNameSearch, Comments, "x", true);

                    TempBase.Insert(0, MethodCode);

                    TempBase = TempBase.Collect(ConvertFieldToMethod.Supply2(FunctionNameSearch));

                    TempBase.Each((i2, Str) =>
                    {
                        int Cutoff = -1;
                        if (i2 > 0)
                            {
                            if (Str.Contains(CodeExplodeGenerics.SubtractGenericTypeLayer2) ||
                                Str.Contains(CodeExplodeGenerics.SubtractArgumentTypeLayer2))
                                {
                                Str = Str.Replace(CodeExplodeGenerics.SubtractGenericTypeLayer2, CodeExplodeGenerics.SubtractGenericType[i2 - 1]);
                                Str = Str.Replace(CodeExplodeGenerics.SubtractArgumentTypeLayer2, CodeExplodeGenerics.SubtractArgumentType[i2 - 1]);
                                Cutoff = i2;
                                }
                            }

                        Out += Str;
                        if (Cutoff > 1)
                            {
                            List<string> Explodes = CodeExplode(Member, Str, Replacements, FunctionNameSearch, Comments, "", true);
                            Explodes.RemoveRange(0, Cutoff);
                            Explodes.Each(Code =>
                            {
                                if (!Out.Contains(Code))
                                    Out += Code;
                            });
                            }
                        else
                            {
                            CodeExplode(Member, Str, Replacements, FunctionNameSearch, Comments, "", true).Each(Code =>
                            {
                                if (!Out.Contains(Code))
                                    Out += Code;
                            });
                            }
                    });
                    }
                else
                    {
                    CodeExplode(Member, MethodCode, Replacements, FunctionNameSearch, Comments, "", false).Each(Code =>
                    {
                        if (!Out.Contains(Code))
                            Out += Code;
                    });
                    }

                return Out.Surround($"#region {Member.Name}\r\n", "#endregion;\r\n");
            };
            public static readonly Func<string, string, string> ConvertFieldToMethod = (Str, FunctionName) =>
                {

                    Str = Str.Replace("public static readonly", "public static");
                    if (Str.Contains("> = (") || Str.Contains($"{FunctionName} = (") || Str.Contains("/ = ("))
                        {
                        Str = Str.Replace($"{FunctionName} = (", $"{FunctionName}()\r\n{{\r\nreturn (");
                        Str = Str.Replace("> = (", ">()\r\n{\r\n return (");
                        Str = Str.Replace("/ = (", "/()\r\n{\r\n return (");
                        if (!Str.EndsWith(";") && !Str.EndsWith(";\r\n"))
                            Str += ";";
                        Str += "\r\n}\r\n";
                        }
                    return Str;
                };

            public static readonly Func<MemberInfo, string, List<List<string>>, string, string, string, bool, List<string>> CodeExplode = (Member, Code, Replacements, FunctionNameSearch, Comments, NumberSeparator, AppendNumber1ToFunctionName) =>
            {
                var Out = new List<string>();
                string LastFunctionName = FunctionNameSearch;
                if (Member.Name.Contains("Merge"))
                    {
                    }
                string LastAddition = ConvertFieldToMethod(Code, LastFunctionName);
                int Count = Replacements.Count;

                0.To(Count - 1, i =>
                {
                    bool ReplacementsMade = false;
                    Replacements.Each(Repl =>
                    {
                        if (Repl.Count <= i + 1)
                            return;
                        if (!Repl[i].IsEmpty() && (LastAddition.Contains(Repl[i]) || Repl[i].Contains("[MethodName]")))
                            {
                            string Replacement = Repl[i];
                            string Replacement2 = Repl[i + 1];
                            string NewFunctionName = FunctionNameSearch + (AppendNumber1ToFunctionName || i > 0 ? NumberSeparator + (i + 1).ToString() : "");

                            if (Replacement.Contains("[MethodName]"))
                                Replacement = Replacement.Replace("[MethodName]", LastFunctionName.Trim());
                            if (Replacement2.Contains("[MethodName]"))
                                Replacement2 = Replacement2.Replace("[MethodName]", NewFunctionName.Trim());


                            if (LastAddition.Contains(Replacement))
                                {
                                ReplacementsMade = true;
                                LastAddition = LastAddition.Replace(Replacement, Replacement2);
                                LastAddition = LastAddition.Replace(LastFunctionName, NewFunctionName);

                                if (LastAddition.Contains("<T1><T1>"))
                                    {
                                    }

                                LastFunctionName = NewFunctionName;
                                }
                            }
                    });
                    if (ReplacementsMade)
                        {
                        string Str = "";
                        if (!LastAddition.Contains(Comments) && !Comments.IsEmpty())
                            Str += Lang.CommentSummary(Comments);
                        Str += LastAddition;
                        Out.Add(Str);
                        }
                });
                return Out;
            };
            #endregion
            #region LogicMemberInfoToExtensionStrings
            public static readonly Func<Lists<string, MemberInfo>, string, List<string>, string> LogicMemberInfoToExtensionStrings = (Members, ForceComment, ForceParamNames) =>
            {
                string Out = "";
                string LastName = "";

                if (Members.Count == 0)
                    return "";

                0.To(Members.Count - 1, i =>
                {
                    List<string> ParamNames = ForceParamNames;
                    string Comment = ForceComment;
                    bool ExtendExplosions = false;
                    var Attr = Members.List2[i].GetAttribute<CodeExplodeExtensionMethod>();
                    if (Attr != null)
                        {
                        if (Comment.IsEmpty())
                            Comment = Attr.Comments;
                        if (!Attr.ParameterNames.IsEmpty())
                            ParamNames = Attr.ParameterNames.List();

                        ExtendExplosions = Attr.ExtendExplosions;
                        }

                    if (Members.List1[i] != LastName)
                        {
                        if (i > 0)
                            Out += "#endregion\r\n";
                        Out += $"#region {Members.List1[i]}\r\n";
                        Out += LogicMemberInfoToExtensionString(Members.List2[i], Members.List1[i], Comment, ParamNames);
                        }
                    else
                        {
                        Out += LogicMemberInfoToExtensionString(Members.List2[i], Members.List1[i], Comment, ParamNames);
                        }

                    if (i == Members.Count - 1)
                        Out += "#endregion\r\n";

                    LastName = Members.List1[i];

                    if (ExtendExplosions)
                        {
                        List<MemberInfo> ExplodedMembers = MemberInfoGetExplodedMembers(Members.List2[i]);
                        List<string> ExplodedNames = new string[ExplodedMembers.Count].Fill(Members.List1[i]).List();
                        Out += LogicMemberInfoToExtensionStrings(new Lists<string, MemberInfo>(ExplodedNames, ExplodedMembers), Comment, ParamNames);
                        }
                });
                return Out;
            };
            #endregion
            #region LogicMemberInfoToExtensionString
            public static readonly Func<MemberInfo, string, string, List<string>, string> LogicMemberInfoToExtensionString = (Member, FunctionName, Comment, ParamNames) =>
            {
                Type FieldType;

                var Info = Member as FieldInfo;

                if (Info != null && Info.IsStatic)
                    {
                    FieldType = Info.FieldType;
                    }
                else if (Member is MethodInfo && ((MethodInfo)Member).IsStatic)
                    {
                    FieldType = ((MethodInfo)Member).ReturnType;
                    }
                else
                    throw new ArgumentException("Member must be static.");

                Type[] AllParamTypes = FieldType.GetGenericArguments();
                bool ReturnValue = FieldType.Name.StartsWith("Func");

                Type[] ParamTypes = ReturnValue
                    ? AllParamTypes.First((uint)AllParamTypes.Length - 1)
                    : AllParamTypes;

                var ReturnType = ReturnValue ? AllParamTypes.Last() : typeof(void);

                var Params = new Lists<string, Type>();

                bool NoParams = ParamNames.IsEmpty();
                if (NoParams)
                    {
                    ParamNames = new string[ParamTypes.Length].Fill("o").List();
                    }
                bool ExecuteResult = false;
                if (Member.HasAttribute(typeof(CodeExplodeExtensionMethod), true))
                    {
                    var Attr = Member.GetAttribute<CodeExplodeExtensionMethod>();
                    // ReSharper disable once InvocationIsSkipped
                    Debug.Assert(Attr != null, "Attr != null");
                    Comment = Attr?.Comments;
                    ExecuteResult = Attr?.ExecuteResult == true;

                    if (Attr?.ParameterNames.IsEmpty() == false)
                        {
                        ParamNames = Attr.ParameterNames.List();
                        }
                    ParamTypes.Each((i, Param) =>
                    {
                        Params.Add(ParamNames[i], Param);
                    });
                    }
                else if (NoParams)
                    {
                    ParamTypes.Each((i, Param) =>
                    {
                        Params.Add(ParamNames[i] + (i > 0 ? i.ToString() : ""), Param);
                    });
                    }
                else
                    {
                    if (ParamTypes.Count() != ParamNames.Count())
                        {
                        }
                    ParamTypes.Each((i, Param) =>
                    {
                        Params.Add(ParamNames[i], Param);
                    });
                    }

                string Declaration = Lang.GetExtensionMethodDeclaration(FunctionName, Params, ReturnType, Comment, Member.MemberType, ExecuteResult);
                if (CodeExploder.DeclaredExtensionCache.Contains(Declaration))
                    {
                    return "";
                    }
                CodeExploder.DeclaredExtensionCache.Add(Declaration);
                string Out = Declaration;
                var Member2 = Member as MethodInfo;

                Member2?.GetGenericArguments().Each(Arg =>
                {
                    Type[] Constraints = Arg.GetGenericParameterConstraints();
                    if (!Constraints.IsEmpty())
                        {
                        }
                });

                Out += Lang.GetExtensionMethodBody(Member.DeclaringType, Member.Name, Params, ReturnType, Member.MemberType, ExecuteResult);
                return Out;
            };
            #endregion
            #region LanguageGetCodeFiles
            public static readonly Func<string, List<FileInfo>> LanguageGetCodeFiles = F<string, List<FileInfo>>(Str =>
            {
                return Directory.GetFiles(Str, $"*{Dynamic.CodeExplode.ExplodeFileType}", SearchOption.AllDirectories).List().Select(
                    Str2 => !Str2.ToLower().Contains(CodeExploder.CodeExplodeLocation?.ToLower() ?? "#")).Convert(Str3 => new FileInfo(Str3));
            }).Cache("CodeExplode_FileInfoCache");
            #endregion
            #region MemberInfoGetExplodedMembers
            public static readonly Func<MemberInfo, List<MemberInfo>> MemberInfoGetExplodedMembers = Member =>
            {
                var MemberType = Member.DeclaringType;
                var ExplodeAttr = MemberType.GetAttribute<CodeExplodeLogic>();
                var ExplodeType = ExplodeAttr?.OutputType;

                if (ExplodeType != null)
                    {
                    List<MemberInfo> ExplodeTypeMembers = ExplodeType.GetMembers().List();
                    return ExplodeTypeMembers.Select(Info =>
                    {
                        return Info.Name.StartsWith(Member.Name) && Info.Name.Length - Member.Name.Length >= 0 &&
                            Info.Name.Length - Member.Name.Length <= 3;
                    });
                    }
                return new List<MemberInfo>();
            };
            #endregion
            }
        }
    }

namespace LCore.Dynamic
    {
    public class CodeExploder
        {
        public static readonly List<string> DeclaredExtensionCache = new List<string>();
        public static string CodeRootLocation = "";
        public static string CodeExplodeLocation = "";

        private const string FileExtension = ".cs";

        private static readonly Func<List<Type>> _ExplodeTypeFunc = L.Lang.GetAssemblyTypesWithAttribute.Supply(typeof(CodeExplode))
            .Cache("CodeExplode_ExplodeTypes");

        private static Lists<string, string> _GlobalFindReplace;
        public static Lists<string, string> GlobalFindReplace
            {
            /*A*/
            /*A,*/
            /*,A*/
            /*-T{1-16}*/
            /*-O{1-16}*/
            /*-O{1-16}*/

            get
                {
                if (_GlobalFindReplace == null)
                    {
                    _GlobalFindReplace = new Lists<string, string>();
                    _GlobalFindReplace.Add("/*A*/, ", "/*A*/");
                    _GlobalFindReplace.Add("/*A,*/, ", "/*A,*/");
                    _GlobalFindReplace.Add("/*,A*/, ", "/*,A*/");
                    1.To(16, i =>
                    {
                        1.For(i + 1, j =>
                          {
                              string ArgStr = new string[j].Fill("T").Collect((i2, Str) => $"{Str}{i2 + 1}").Combine(", ");
                              _GlobalFindReplace.Add($"/*-T{i}*/<{ArgStr}>", $"/*-T{i}*/");
                              _GlobalFindReplace.Add($"/*-T{i}*/<{ArgStr}, U>", $"/*-T{i}*/<U>");
                              _GlobalFindReplace.Add($"/*-T{i}*/{ArgStr}, U", $"/*-T{i}*/U");
                              _GlobalFindReplace.Add($"/*-T{i}*/{ArgStr}, ", $"/*-T{i}*/");
                              _GlobalFindReplace.Add($"/*-T{i}*/{ArgStr}", $"/*-T{i}*/");
                              _GlobalFindReplace.Add($"<{ArgStr}>/*-T{i}*/", $"/*-T{i}*/");
                              _GlobalFindReplace.Add($"<{ArgStr}, U>/*-T{i}*/", $"<U>/*-T{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr}, /*-T{i}*/", $"/*-T{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr}, U/*-T{i}*/", $"U/*-T{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr}/*-T{i}*/", $"/*-T{i}*/");
                              string ArgStr3 = new string[j].Fill("o").Collect((i2, Str) => Str + (i2 + 1)).Combine(", ");
                              _GlobalFindReplace.Add($"/*-O{i}*/{ArgStr3}, ", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"/*-O{i}*/{ArgStr3}", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr3}, /*-O{i}*/", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr3}/*-O{i}*/", $"/*-O{i}*/");
                              return true;
                          });
                        17.For(i, j =>
                        {
                            string ArgStr = new string[i].Fill("T").Collect((i2, Str) => Str + (i2 + 1)).Combine(", ");
                            string ArgStr2 = new string[j - i].Fill("T").Collect((i2, Str) => Str + (i + i2 + 1)).Combine(", ");
                            _GlobalFindReplace.Add($"<{ArgStr}, {ArgStr2}>/*-T{i}*/", $"<{ArgStr2}>/*-T{i}*/");
                            _GlobalFindReplace.Add($"<{ArgStr}, {ArgStr2}, U>/*-T{i}*/", $"<{ArgStr2}, U>/*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}, /*-T{i}*/", $"{ArgStr2}, /*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}, U/*-T{i}*/", $"{ArgStr2}, U/*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}/*-T{i}*/", $"{ArgStr2}/*-T{i}*/");
                            string ArgStr3 = new string[i].Fill("o").Collect((i2, Str) => Str + (i2 + 1)).Combine(", ");
                            string ArgStr4 = new string[j - i].Fill("o").Collect((i2, Str) => Str + (i + i2 + 1)).Combine(", ");
                            _GlobalFindReplace.Add($"{ArgStr3}, {ArgStr4}, /*-O{i}*/", $"{ArgStr4}/*-O{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr3}, {ArgStr4}/*-O{i}*/", $"{ArgStr4}/*-O{i}*/");
                            return true;
                        });
                    });
                    }
                return _GlobalFindReplace;
                }
            }

        public List<Type> ExplodeTypes => _ExplodeTypeFunc();

        public CodeExploder(string CodeRootDir = "", string CodeExplodeDir = "")
            {
            CodeRootLocation = CodeRootDir;
            CodeExplodeLocation = CodeExplodeDir;
            }
        public void BackupAllExplodeFiles()
            {
            this.ExplodeTypes.Each(this.BackupType);
            }
        public void BackupType(Type Type)
            {
            if (!CodeRootLocation.IsEmpty())
                {
                List<CodeExplode> Attributes = Type.GetAttributes<CodeExplode>(true);
                Attributes.Each(Attr =>
                {
                    string FileName = L.File.CombinePaths(CodeExplodeLocation, Attr.CodeFileName + CodeExplode.ExplodeFileType);
                    string Data = $"/*\r\n{L.File.GetFileContents(FileName).ByteArrayToString()}\r\n*/";
                    Data = CodeExplodeGenerics.RemoveGenericComments(Data);
                    File.WriteAllText(FileName.Replace(CodeExplode.ExplodeFileType, CodeExplode.BackupSuffix + CodeExplode.ExplodeFileType), Data);
                });
                }
            }
        public string ExplodeAllTypes()
            {
            return this.ExplodeTypes.Convert(this.ExplodeType).Combine();
            }
        public string ExplodeAllTypes(Func<MemberInfo, bool> MethodSelector)
            {
            return this.ExplodeTypes.Convert(Type => this.ExplodeType(Type, MethodSelector)).Combine();
            }

        public string ExplodeType(Type Type)
            {
            return this.ExplodeType(Type, null);
            }

        public string ExplodeType(Type Type, [CanBeNull]Func<MemberInfo, bool> MethodSelector)
            {
            if (MethodSelector == null)
                MethodSelector = Member => true;

            List<MemberInfo> Members = Type.GetMembers().Select(Member => Member.HasAttribute(typeof(CodeExplodeMember), true)).List();

            List<CodeExplode> Attributes = Type.GetAttributes<CodeExplode>(true);

            return Attributes.Convert(Attr =>
                {
                    List<MemberInfo> Temp = Members.Select(Attr.ExplodeMember).Select(MethodSelector);

                    var Members2 = new Lists<string, MemberInfo>(Temp.Convert(
                        Member => Member.GetAttribute<CodeExplodeMember>()?.MethodName), Temp);

                    string Out =
                            L.Lang.Using(this.UsingLibraries,
                            L.Lang.Namespace(
                                L.Lang.Class(
                                    L.Lang.Region(
                                        Attr.ExplodeCode(Members2),
                                    Attr.CodeRegionTitle),
                                Attr.ClassName, true),
                            Attr.CodeNamespace));

                    if (!CodeRootLocation.IsEmpty() &&
                    !CodeExplodeLocation.IsEmpty() &&
                    !Out.IsEmpty())
                        {
                        string FileName = L.File.CombinePaths(CodeExplodeLocation, Attr.CodeFileName + CodeExplode.ExplodeFileType);
                        //Out = CodeExplodeGenerics.RemoveGenericComments(Out);
                        0.To(GlobalFindReplace.List1.Count - 1, i =>
                        {
                            Out = Out.ReplaceAll(GlobalFindReplace.List1[i], GlobalFindReplace.List2[i]);
                        });
                        File.WriteAllText(FileName, Out);
                        }
                    return Out;
                }).Combine();
            }
        public string[] UsingLibraries =>
            new[]
            {
                "System",
                "System.Collections.Generic"
            };

        private string GetTypeFileDirectory()
            {
            return L.File.CombinePaths(CodeExplodeLocation);
            }
        // ReSharper disable once SuggestBaseTypeForParameter
        private string GetTypeFileName(Type Type)
            {
            var Explode = Type.GetAttribute<CodeExplode>();
            return $"{Explode?.CodeRegionTitle}_Explode{FileExtension}";
            }
        }
    }