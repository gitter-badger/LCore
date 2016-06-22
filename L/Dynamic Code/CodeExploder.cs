using System;

using LCore.Extensions;
using LCore.Dynamic;
using LCore.Tools;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace LCore.Extensions
    {
    public partial class Logic
        {
        #region LogicType_ToExtensionStrings
        public static Func<Type, string> LogicType_ToExtensionStrings = t =>
        {
            List<MemberInfo> Members = t.GetMembers().Select(
                m => (m is FieldInfo && ((FieldInfo)m).IsStatic)
                    || (m is MethodInfo && ((MethodInfo)m).IsStatic)).List();
            List<string> MemberNames = Members.Convert(m => m.Name);
            Lists<string, MemberInfo> Members2 = new Lists<string, MemberInfo>(MemberNames, Members);

            return LogicMemberInfo_ToExtensionStrings(Members2, "", null);
        };
        #endregion
        #region LogicMemberInfo_Explode
        public static readonly Func<Lists<string, MemberInfo>, string> LogicMemberInfo_Explode =
            Members => Members.List2.Convert(MemberInfo_Explode).Combine("\r\n");
        #endregion
        #region MemberInfo_GetCode
        public static Func<MemberInfo, string> MemberInfo_GetCode = Member =>
            {
                string CodeLocation = CodeExploder.CodeRootLocation;
                if (CodeLocation.IsEmpty())
                    throw new Exception("CodeExploder.CodeRootLocation has not been set");
                return MemberInfo_GetCodeFromPath(CodeLocation, Member);
            };
        #endregion
        #region MemberInfo_GetCodeFromPath
        public static Func<string, MemberInfo, string> MemberInfo_GetCodeFromPath = (Path, Member) =>
            {
                List<FileInfo> Files = Language_GetCodeFiles(Path);
                string Searchstr = $"{L.Language_CleanGenericTypeName(Member.GetMemberType().ToString())} {Member.Name}";
                string Searchstr2 = Language_ReplaceNativeTypes(Searchstr);
                string Searchstr3 = Member.Name + CodeExplodeGenerics.MethodActionToken;
                string Searchstr4 = Member.Name + CodeExplodeGenerics.MethodFuncToken;
                Searchstr = Searchstr.Replace(",", ", ");
                string Code = "";
                int Index = -1;

                FileInfo file = Files.First(f =>
                {
                    string FileContents = Language_GetCodeString(f.FullName);

                    if (FileContents.Contains(Searchstr4))
                        {
                        Searchstr = Searchstr4;
                        Code = FileContents;
                        Index = Code.IndexOf(Searchstr);
                        return true;
                        }
                    if (FileContents.Contains(Searchstr3))
                        {
                        Searchstr = Searchstr3;
                        Code = FileContents;
                        Index = Code.IndexOf(Searchstr);
                        return true;
                        }
                    if (FileContents.Contains(Searchstr2))
                        {
                        Searchstr = Searchstr2;
                        Code = FileContents;
                        Index = Code.IndexOf(Searchstr);
                        return true;
                        }
                    if (FileContents.Contains(Searchstr))
                        {
                        Code = FileContents;
                        Index = Code.IndexOf(Searchstr);
                        return true;
                        }
                    return false;
                });
                if (file == null)
                    {
                    return "";
                    }
                string temp = Code.Substring(0, Index);
                Index = temp.LastIndexOf("\r\n", StringComparison.Ordinal);
                Code = Code.Substring(Index + 2);
                int OpenBraceIndex = Code.IndexOf('{');
                int EndIndex = Language_FindMate(Code, OpenBraceIndex) + 1;

                string Out = $"{Code.Substring(0, EndIndex)}\r\n";

                if (Out.IsEmpty())
                    {
                    }
                return Out;
            };
        #endregion
        #region Language_FindMate

        public static readonly Func<string, int, int> Language_FindMate = (Str, Start) =>
        {
            char open = Str[Start];
            char close = Language_CloseSequences[Language_OpenSequences.List().IndexOf(Str[Start].ToString())][0];
            int Depth = 0;
            int Index = Start + 1;
            int Out = -1;
            Index.For(Str.Length - 1, i =>
            {
                if (Str[i] == open)
                    Depth++;
                if (Str[i] == close)
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
        #region Language_GetCodeString
        public static readonly Func<string, string> Language_GetCodeString = L.F<string, string>(
            File => GetFileContents(File).ByteArrayToString()).Cache("Language_GetCodeString");
        #endregion
        #region MemberInfo_Explode
        public static readonly Func<MemberInfo, string> MemberInfo_Explode = Member =>
        {
            List<List<string>> Replacements = new List<List<string>>();
            string Comments = "";
            if (Member.MemberHasAttribute(typeof(CodeExplodeGenerics), true))
                {
                CodeExplodeGenerics Attr = Member.MemberGetAttribute<CodeExplodeGenerics>(true);
                Comments = Attr.Comments;
                if (!Attr.Replacements.IsEmpty())
                    {
                    Replacements.AddRange(Attr.Replacements);
                    }
                }
            string Out = "";
            string MethodCode = MemberInfo_GetCode(Member);
            string FunctionNameSearch = $" {Member.Name}";
            bool Level2_Tokens = CodeExplodeGenerics.ContainsMultiLevelTokens(MethodCode);

            if (Level2_Tokens)
                {
                List<List<string>> Replacements2 = CodeExplodeGenerics.GetLevel2Replacements();
                List<string> TempBase = Code_Explode(Member, MethodCode, Replacements2, FunctionNameSearch, Comments, "x", true);

                TempBase.Insert(0, MethodCode);

                TempBase = TempBase.Collect(ConvertFieldToMethod.Supply2(FunctionNameSearch));

                TempBase.EachI((i2, s) =>
                {
                    int Cutoff = -1;
                    if (i2 > 0)
                        {
                        if (s.Contains(CodeExplodeGenerics.SubtractGenericType_Layer2) ||
                            s.Contains(CodeExplodeGenerics.SubtractArgumentType_Layer2))
                            {
                            s = s.Replace(CodeExplodeGenerics.SubtractGenericType_Layer2, CodeExplodeGenerics.SubtractGenericType[i2 - 1]);
                            s = s.Replace(CodeExplodeGenerics.SubtractArgumentType_Layer2, CodeExplodeGenerics.SubtractArgumentType[i2 - 1]);
                            Cutoff = i2;
                            }
                        }

                    Out += s;
                    if (Cutoff > 1)
                        {
                        List<string> Explodes = Code_Explode(Member, s, Replacements, FunctionNameSearch, Comments, "", true);
                        Explodes.RemoveRange(0, Cutoff);
                        Explodes.Each(c =>
                        {
                            if (!Out.Contains(c))
                                Out += c;
                        });
                        }
                    else
                        {
                        Code_Explode(Member, s, Replacements, FunctionNameSearch, Comments, "", true).Each(c =>
                        {
                            if (!Out.Contains(c))
                                Out += c;
                        });
                        }
                });
                }
            else
                {
                Code_Explode(Member, MethodCode, Replacements, FunctionNameSearch, Comments, "", false).Each(c =>
                {
                    if (!Out.Contains(c))
                        Out += c;
                });
                }

            return Out.Surround($"#region {Member.Name}\r\n", "#endregion;\r\n");
        };
        public static readonly Func<string, string, string> ConvertFieldToMethod = (s, FunctionName) =>
            {

                s = s.Replace("public static readonly", "public static");
                if (s.Contains("> = (") || s.Contains($"{FunctionName} = (") || s.Contains("/ = ("))
                    {
                    s = s.Replace($"{FunctionName} = (", $"{FunctionName}()\r\n{{\r\nreturn (");
                    s = s.Replace("> = (", ">()\r\n{\r\nreturn (");
                    s = s.Replace("/ = (", "/()\r\n{\r\nreturn (");
                    if (!s.EndsWith(";") && !s.EndsWith(";\r\n"))
                        s += ";";
                    s += "\r\n}\r\n";
                    }
                return s;
            };

        public static Func<MemberInfo, string, List<List<string>>, string, string, string, bool, List<string>> Code_Explode = (Member, Code, Replacements, FunctionNameSearch, Comments, NumberSeparator, AppendNumber1ToFunctionName) =>
        {
            List<string> Out = new List<string>();
            string LastFunctionName = FunctionNameSearch;
            if (Member.Name.Contains("Merge"))
                {
                }
            string LastAddition = ConvertFieldToMethod(Code, LastFunctionName);
            int Count = Replacements.Count;

            0.To(Count - 1, i =>
            {
                bool ReplacementsMade = false;
                Replacements.Each(rep =>
                {
                    if (rep.Count <= i + 1)
                        return;
                    if (!rep[i].IsEmpty() && (LastAddition.Contains(rep[i]) || rep[i].Contains("[MethodName]")))
                        {
                        string Replacement = rep[i];
                        string Replacement2 = rep[i + 1];
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
                    string s = "";
                    if (!LastAddition.Contains(Comments) && !Comments.IsEmpty())
                        s += Language_CommentSummary(Comments);
                    s += LastAddition;
                    Out.Add(s);
                    }
            });
            return Out;
        };
        #endregion
        #region LogicMemberInfo_ToExtensionStrings
        public static readonly Func<Lists<string, MemberInfo>, string, List<string>, string> LogicMemberInfo_ToExtensionStrings = (Members, ForceComment, ForceParamNames) =>
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
                CodeExplodeExtensionMethod Attr = Members.List2[i].MemberGetAttribute<CodeExplodeExtensionMethod>(true);
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
                    Out += LogicMemberInfo_ToExtensionString(Members.List2[i], Members.List1[i], Comment, ParamNames);
                    }
                else
                    {
                    Out += LogicMemberInfo_ToExtensionString(Members.List2[i], Members.List1[i], Comment, ParamNames);
                    }

                if (i == Members.Count - 1)
                    Out += "#endregion\r\n";

                LastName = Members.List1[i];

                if (ExtendExplosions)
                    {
                    List<MemberInfo> ExplodedMembers = MemberInfo_GetExplodedMembers(Members.List2[i]);
                    List<string> ExplodedNames = new string[ExplodedMembers.Count].Fill(Members.List1[i]).List();
                    Out += LogicMemberInfo_ToExtensionStrings(new Lists<string, MemberInfo>(ExplodedNames, ExplodedMembers), Comment, ParamNames);
                    }
            });
            return Out;
        };
        #endregion
        #region LogicMemberInfo_ToExtensionString
        public static readonly Func<MemberInfo, string, string, List<string>, string> LogicMemberInfo_ToExtensionString = (Member, FunctionName, Comment, ParamNames) =>
        {
            Type FieldType;

            FieldInfo info = Member as FieldInfo;
            if (info != null && info.IsStatic)
                {
                FieldType = info.FieldType;
                }
            else if (Member is MethodInfo && ((MethodInfo)Member).IsStatic)
                {
                FieldType = ((MethodInfo)Member).ReturnType;
                }
            else
                throw new ArgumentException("Member must be static.");

            Type[] AllParamTypes = FieldType.GetGenericArguments();
            bool ReturnValue = FieldType.Name.StartsWith("Func");

            Type[] ParamTypes = ReturnValue ? AllParamTypes.First(AllParamTypes.Length - 1) : AllParamTypes;

            Type ReturnType = ReturnValue ? AllParamTypes.Last() : typeof(void);

            Lists<string, Type> Params = new Lists<string, Type>();

            bool NoParams = ParamNames.IsEmpty();
            if (NoParams)
                {
                ParamNames = new string[ParamTypes.Length].Fill("o").List();
                }
            bool ExecuteResult = false;
            if (Member.MemberHasAttribute(typeof(CodeExplodeExtensionMethod), true))
                {
                CodeExplodeExtensionMethod Attr = Member.MemberGetAttribute<CodeExplodeExtensionMethod>(true);
                Comment = Attr.Comments;
                ExecuteResult = Attr.ExecuteResult;

                if (!Attr.ParameterNames.IsEmpty())
                    {
                    ParamNames = Attr.ParameterNames.List();
                    }
                ParamTypes.EachI((i, mp) =>
                {
                    Params.Add(ParamNames[i], mp);
                });
                }
            else if (NoParams)
                {
                ParamTypes.EachI((i, mp) =>
                {
                    Params.Add(ParamNames[i] + (i > 0 ? i.ToString() : ""), mp);
                });
                }
            else
                {
                if (ParamTypes.Count() != ParamNames.Count())
                    {
                    }
                ParamTypes.EachI((i, mp) =>
                {
                    Params.Add(ParamNames[i], mp);
                });
                }

            string Declaration = Language_GetExtensionMethodDeclaration(FunctionName, Params, ReturnType, Comment, Member.MemberType, ExecuteResult);
            if (CodeExploder.DeclaredExtensionCache.Contains(Declaration))
                {
                return "";
                }
            CodeExploder.DeclaredExtensionCache.Add(Declaration);
            string Out = Declaration;
            MethodInfo member = Member as MethodInfo;

            member?.GetGenericArguments().Each(g =>
            {
                Type[] Constraints = g.GetGenericParameterConstraints();
                if (!Constraints.IsEmpty())
                    {
                    }
            });

            Out += Language_GetExtensionMethodBody(Member.DeclaringType, Member.Name, Params, ReturnType, Member.MemberType, ExecuteResult);
            return Out;
        };
        #endregion
        #region Language_GetCodeFiles
        public static readonly Func<string, List<FileInfo>> Language_GetCodeFiles = L.F<string, List<FileInfo>>(s =>
        {
            return Directory.GetFiles(s, $"*{CodeExplode.ExplodeFileType}", SearchOption.AllDirectories).List().Select(
                s2 => !s2.ToLower().Contains(CodeExploder.CodeExplodeLocation.ToLower())).Convert(s3 => new FileInfo(s3));
        }).Cache("CodeExplode_FileInfoCache");
        #endregion
        #region MemberInfo_GetExplodedMembers
        public static readonly Func<MemberInfo, List<MemberInfo>> MemberInfo_GetExplodedMembers = Member =>
        {
            Type MemberType = Member.DeclaringType;
            CodeExplode_ExplodeLogic ExplodeAttr = MemberType.MemberGetAttribute<CodeExplode_ExplodeLogic>(true);
            Type ExplodeType = ExplodeAttr.OutputType;
            if (ExplodeType != null)
                {
                List<MemberInfo> ExplodeTypeMembers = ExplodeType.GetMembers().List();
                return ExplodeTypeMembers.Select(m =>
                {
                    return m.Name.StartsWith(Member.Name) && m.Name.Length - Member.Name.Length >= 0 &&
                        m.Name.Length - Member.Name.Length <= 3;
                });
                }
            return new List<MemberInfo>();
        };
        #endregion
        }
    }

namespace LCore.Dynamic
    {
    public class CodeExploder
        {
        public static List<string> DeclaredExtensionCache = new List<string>();
        public static string CodeRootLocation = "";
        public static string CodeExplodeLocation = "";

        private const string FileExtension = ".cs";

        private static readonly Func<List<Type>> ExplodeTypeFunc = Logic.GetAssemblyTypesWithAttribute.Supply(typeof(CodeExplode))
            .Cache("CodeExplode_ExplodeTypes");

        private static Lists<string, string> _GlobalFindReplace;
        public static Lists<string, string> GlobalFindReplace
            {
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
                              string ArgStr = new string[j].Fill("T").CollectI((i2, s) => s + (i2 + 1)).Combine(", ");
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
                              string ArgStr3 = new string[j].Fill("o").CollectI((i2, s) => s + (i2 + 1)).Combine(", ");
                              _GlobalFindReplace.Add($"/*-O{i}*/{ArgStr3}, ", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"/*-O{i}*/{ArgStr3}", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr3}, /*-O{i}*/", $"/*-O{i}*/");
                              _GlobalFindReplace.Add($"{ArgStr3}/*-O{i}*/", $"/*-O{i}*/");
                              return true;
                          });
                        17.For(i, j =>
                        {
                            string ArgStr = new string[i].Fill("T").CollectI((i2, s) => s + (i2 + 1)).Combine(", ");
                            string ArgStr2 = new string[j - i].Fill("T").CollectI((i2, s) => s + (i + i2 + 1)).Combine(", ");
                            _GlobalFindReplace.Add($"<{ArgStr}, {ArgStr2}>/*-T{i}*/", $"<{ArgStr2}>/*-T{i}*/");
                            _GlobalFindReplace.Add($"<{ArgStr}, {ArgStr2}, U>/*-T{i}*/", $"<{ArgStr2}, U>/*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}, /*-T{i}*/", $"{ArgStr2}, /*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}, U/*-T{i}*/", $"{ArgStr2}, U/*-T{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr}, {ArgStr2}/*-T{i}*/", $"{ArgStr2}/*-T{i}*/");
                            string ArgStr3 = new string[i].Fill("o").CollectI((i2, s) => s + (i2 + 1)).Combine(", ");
                            string ArgStr4 = new string[j - i].Fill("o").CollectI((i2, s) => s + (i + i2 + 1)).Combine(", ");
                            _GlobalFindReplace.Add($"{ArgStr3}, {ArgStr4}, /*-O{i}*/", $"{ArgStr4}/*-O{i}*/");
                            _GlobalFindReplace.Add($"{ArgStr3}, {ArgStr4}/*-O{i}*/", $"{ArgStr4}/*-O{i}*/");
                            return true;
                        });
                    });
                    }
                return _GlobalFindReplace;
                }
            }

        public List<Type> ExplodeTypes => ExplodeTypeFunc();

        public CodeExploder(string CodeRootDir = "", string CodeExplodeDir = "")
            {
            CodeRootLocation = CodeRootDir;
            CodeExplodeLocation = CodeExplodeDir;
            }
        public void BackupAllExplodeFiles()
            {
            this.ExplodeTypes.Each(this.BackupType);
            }
        public void BackupType(Type t)
            {
            if (!CodeRootLocation.IsEmpty())
                {
                List<CodeExplode> attrs = t.MemberGetAttributes<CodeExplode>(true);
                attrs.Each(attr =>
                {
                    string FileName = Logic.CombinePaths(CodeExplodeLocation, attr.CodeFileName + CodeExplode.ExplodeFileType);
                    string Data = $"/*\r\n{Logic.GetFileContents(FileName).ByteArrayToString()}\r\n*/";
                    Data = CodeExplodeGenerics.RemoveGenericComments(Data);
                    File.WriteAllText(FileName.Replace(CodeExplode.ExplodeFileType, CodeExplode.BackupSuffix + CodeExplode.ExplodeFileType), Data);
                });
                }
            }
        public string ExplodeAllTypes()
            {
            return this.ExplodeTypes.Convert(this.ExplodeType).Combine();
            }
        public string ExplodeType(Type t)
            {
            List<MemberInfo> Members = t.GetMembers().Select(m => m.MemberHasAttribute(typeof(CodeExplodeMember), true)).List();

            List<CodeExplode> attrs = t.MemberGetAttributes<CodeExplode>(true);

            return attrs.Convert(attr =>
            {
                List<MemberInfo> temp = Members.Select(attr.ExplodeMember);
                Lists<string, MemberInfo> Members2 = new Lists<string, MemberInfo>(temp.Convert(m => m.MemberGetAttribute<CodeExplodeMember>(true).MethodName), temp);

                string Out =
                        Logic.Language_Using(this.UsingLibraries,
                        Logic.Language_Namespace(
                            Logic.Language_Class(
                                Logic.Language_Region(
                                    attr.ExplodeCode(Members2),
                                attr.CodeRegionTitle),
                            attr.ClassName, true),
                        attr.CodeNamespace));

                if (!CodeRootLocation.IsEmpty() && !Out.IsEmpty())
                    {
                    string FileName = Logic.CombinePaths(CodeExplodeLocation, attr.CodeFileName + CodeExplode.ExplodeFileType);
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
            return Logic.CombinePaths(CodeExplodeLocation);
            }
        // ReSharper disable once SuggestBaseTypeForParameter
        private string GetTypeFileName(Type t)
            {
            CodeExplode ce = t.MemberGetAttribute<CodeExplode>(true);
            return $"{ce.CodeRegionTitle}_Explode{FileExtension}";
            }
        }
    }