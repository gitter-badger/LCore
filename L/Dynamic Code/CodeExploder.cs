using System;
using LCore;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using LCore.Dynamic;

namespace LCore
	{
	public partial class Logic
		{
		#region LogicType_ToExtensionStrings
		public static Func<Type, String> LogicType_ToExtensionStrings = (t) =>
		{
			List<MemberInfo> Members = t.GetMembers().Select((m) =>
			{
				return (m is FieldInfo && ((FieldInfo)m).IsStatic)
					|| (m is MethodInfo && ((MethodInfo)m).IsStatic);
			}).List();
			List<String> MemberNames = Members.Convert(L.MemberInfo_GetName);
			Lists<String, MemberInfo> Members2 = new Lists<string, MemberInfo>(MemberNames, Members);

			return LogicMemberInfo_ToExtensionStrings(Members2, "", null);
		};
		#endregion
		#region LogicMemberInfo_Explode
		public static Func<Lists<String, MemberInfo>, String> LogicMemberInfo_Explode = (Members) =>
		{
			return Members.List2.Convert(MemberInfo_Explode).Combine("\r\n");
		};
		#endregion
		#region MemberInfo_GetCode
		public static Func<MemberInfo, String> MemberInfo_GetCode = (Member) =>
			{
				String CodeLocation = CodeExploder.CodeRootLocation;
				if (CodeLocation.IsEmpty())
					throw new Exception("CodeExploder.CodeRootLocation has not been set");
				return MemberInfo_GetCodeFromPath(CodeLocation, Member);
			};
		#endregion
		#region MemberInfo_GetCodeFromPath
		public static Func<String, MemberInfo, String> MemberInfo_GetCodeFromPath = (Path, Member) =>
			{
				List<FileInfo> Files = Language_GetCodeFiles(Path);
				String Searchstr = L.Language_CleanGenericTypeName(Member.GetMemberType().ToString()) + " " + Member.Name;
				String Searchstr2 = L.Language_ReplaceNativeTypes(Searchstr);
				String Searchstr3 = Member.Name + CodeExplodeGenerics.MethodActionToken;
				String Searchstr4 = Member.Name + CodeExplodeGenerics.MethodFuncToken;
				Searchstr = Searchstr.Replace(",", ", ");
				String Code = "";
				int Index = -1;

				FileInfo file = Files.First((f) =>
				{
					String FileContents = Language_GetCodeString(f.FullName);

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
				else
					{
					String temp = Code.Substring(0, Index);
					Index = temp.LastIndexOf("\r\n");
					Code = Code.Substring(Index + 2);
					int OpenBraceIndex = Code.IndexOf('{');
					int EndIndex = L.Language_FindMate(Code, OpenBraceIndex) + 1;

					String Out = Code.Substring(0, EndIndex) + "\r\n";

					if (Out.IsEmpty())
						{
						}
					return Out;
					}
			};
		#endregion
		#region Language_FindMate
		public static Func<String, int, int> Language_FindMate = (Str, Start) =>
		{
			char open = Str[Start];
			char close = L.Language_CloseSequences[L.Language_OpenSequences.List().IndexOf(Str[Start].ToString())][0];
			int Depth = 0;
			int Index = Start + 1;
			int Out = -1;
			(Index).For(Str.Length - 1, (i) =>
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
		public static Func<String, String> Language_GetCodeString = L.F<String, String>((File) =>
		{
			return L.GetFileContents(File).ByteArrayToString();
		}).Cache("Language_GetCodeString");
		#endregion
		#region MemberInfo_Explode
		public static Func<MemberInfo, String> MemberInfo_Explode = (Member) =>
		{
			List<List<String>> Replacements = new List<List<String>>();
			String Comments = "";
			if (Member.MemberHasAttribute(typeof(CodeExplodeGenerics), true))
				{
				CodeExplodeGenerics Attr = Member.MemberGetAttribute<CodeExplodeGenerics>(true);
				Comments = Attr.Comments;
				if (!Attr.Replacements.IsEmpty())
					{
					Replacements.AddRange(Attr.Replacements);
					}
				}
			String Out = "";
			String MethodCode = L.MemberInfo_GetCode(Member);
			int Count = Replacements[0].Count;
			String FunctionNameSearch = " " + Member.Name;
			Boolean Level2_Tokens = CodeExplodeGenerics.ContainsMultiLevelTokens(MethodCode);

			if (Level2_Tokens)
				{
				List<List<String>> Replacements2 = CodeExplodeGenerics.GetLevel2Replacements();
				List<String> TempBase = Code_Explode(Member, MethodCode, Replacements2, FunctionNameSearch, Comments, "x", true);

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
						List<String> Explodes = Code_Explode(Member, s, Replacements, FunctionNameSearch, Comments, "", true);
						Explodes.RemoveRange(0, Cutoff);
						Explodes.Each((c) =>
						{
							if (!Out.Contains(c))
								Out += c;
						});
						}
					else
						{
						Code_Explode(Member, s, Replacements, FunctionNameSearch, Comments, "", true).Each((c) =>
						{
							if (!Out.Contains(c))
								Out += c;
						});
						}
				});
				}
			else
				{
				Code_Explode(Member, MethodCode, Replacements, FunctionNameSearch, Comments, "", false).Each((c) =>
				{
					if (!Out.Contains(c))
						Out += c;
				});
				}

			return Out.Surround("#region " + Member.Name + "\r\n", "#endregion;\r\n");
		};
		public static Func<String, String, String> ConvertFieldToMethod = (s, FunctionName) =>
			{

				s = s.Replace("public static readonly", "public static");
				if (s.Contains("> = (") || s.Contains(FunctionName + " = (") || s.Contains("/ = ("))
					{
					s = s.Replace(FunctionName + " = (", FunctionName + "()\r\n{\r\nreturn (");
					s = s.Replace("> = (", ">()\r\n{\r\nreturn (");
					s = s.Replace("/ = (", "/()\r\n{\r\nreturn (");
					if (!s.EndsWith(";") && !s.EndsWith(";\r\n"))
						s += ";";
					s += "\r\n}\r\n";
					}
				return s;
			};

		public static Func<MemberInfo, String, List<List<String>>, String, String, String, Boolean, List<String>> Code_Explode = (Member, Code, Replacements, FunctionNameSearch, Comments, NumberSeparator, AppendNumber1ToFunctionName) =>
		{
			List<String> Out = new List<String>();
			String LastFunctionName = FunctionNameSearch;
			if (Member.Name.Contains("Merge"))
				{
				}
			String LastAddition = ConvertFieldToMethod(Code, LastFunctionName);
			int Count = Replacements.Count;
			Boolean FieldInfoConverted = false;
			(0).To(Count - 1, (i) =>
			{
				Boolean ReplacementsMade = false;
				Replacements.Each((rep) =>
				{
					if (rep.Count <= i + 1)
						return;
					if (!rep[i].IsEmpty() && (LastAddition.Contains(rep[i]) || rep[i].Contains("[MethodName]")))
						{
						String Replacement = rep[i];
						String Replacement2 = rep[i + 1];
						String NewFunctionName = FunctionNameSearch + (AppendNumber1ToFunctionName || i > 0 ? NumberSeparator + (i + 1).ToString() : "");

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
					String s = "";
					if (!LastAddition.Contains(Comments) && !Comments.IsEmpty())
						s += L.Language_CommentSummary(Comments);
					s += LastAddition;
					Out.Add(s);
					}
			});
			return Out;
		};
		#endregion
		#region LogicMemberInfo_ToExtensionStrings
		public static Func<Lists<String, MemberInfo>, String, List<String>, String> LogicMemberInfo_ToExtensionStrings = (Members, ForceComment, ForceParamNames) =>
		{
			String Out = "";
			String LastName = "";

			if (Members.Count == 0)
				return "";

			(0).To(Members.Count - 1, (i) =>
			{
				List<String> ParamNames = ForceParamNames;
				String Comment = ForceComment;
				Boolean ExtendExplosions = false;
				CodeExplodeExtensionMethod Attr = Members.List2[i].MemberGetAttribute<CodeExplodeExtensionMethod>(true);
				if (Attr != null)
					{
					if (Comment.IsEmpty())
						Comment = Attr.Comments;
					if (!Attr.ParameterNames.IsEmpty())
						ParamNames = Attr.ParameterNames.List();

					ExtendExplosions = Attr.ExtendExplosions;
					}

				if (Members.List1[i] != (String)LastName)
					{
					if (i > 0)
						Out += "#endregion\r\n";
					Out += "#region " + Members.List1[i] + "\r\n";
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
					List<MemberInfo> ExplodedMembers = L.MemberInfo_GetExplodedMembers(Members.List2[i]);
					List<String> ExplodedNames = new String[ExplodedMembers.Count].Fill(Members.List1[i]).List();
					Out += LogicMemberInfo_ToExtensionStrings(new Lists<string, MemberInfo>(ExplodedNames, ExplodedMembers), Comment, ParamNames);
					}
			});
			return Out;
		};
		#endregion
		#region LogicMemberInfo_ToExtensionString
		public static Func<MemberInfo, String, String, List<String>, String> LogicMemberInfo_ToExtensionString = (Member, FunctionName, Comment, ParamNames) =>
		{
			Type FieldType = typeof(void);

			if (Member is FieldInfo && ((FieldInfo)Member).IsStatic)
				{
				FieldType = ((FieldInfo)Member).FieldType;
				}
			else if (Member is MethodInfo && ((MethodInfo)Member).IsStatic)
				{
				FieldType = ((MethodInfo)Member).ReturnType;
				}
			else
				throw new ArgumentException("Member must be static.");

			Type[] AllParamTypes = FieldType.GetGenericArguments();
			Boolean ReturnValue = FieldType.Name.StartsWith("Func");

			Type[] ParamTypes = ReturnValue ? AllParamTypes.First(AllParamTypes.Length - 1) : AllParamTypes;

			Type ReturnType = ReturnValue ? AllParamTypes.Last() : typeof(void);

			Lists<String, Type> Params = new Lists<String, Type>();

			Boolean NoParams = ParamNames.IsEmpty();
			if (NoParams)
				{
				ParamNames = new String[ParamTypes.Length].Fill("o").List();
				}
			Boolean ExecuteResult = false;
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

			String Declaration = Language_GetExtensionMethodDeclaration(FunctionName, Params, ReturnType, Comment, Member.MemberType, ExecuteResult);
			if (CodeExploder.DeclaredExtensionCache.Contains(Declaration))
				{
				return "";
				}
			CodeExploder.DeclaredExtensionCache.Add(Declaration);
			String Out = Declaration;
			if (Member is MethodInfo)
				{
				((MethodInfo)Member).GetGenericArguments().Each((g) =>
					 {
						 Type[] Constraints = g.GetGenericParameterConstraints();
						 if (!Constraints.IsEmpty())
							 {
							 //TODO Method Extension constraints
							 }
					 });
				}
			Out += Language_GetExtensionMethodBody(Member.DeclaringType, Member.Name, Params, ReturnType, Member.MemberType, ExecuteResult);
			return Out;
		};
		#endregion
		#region Language_GetCodeFiles
		public static Func<String, List<FileInfo>> Language_GetCodeFiles = L.F<String, List<FileInfo>>((s) =>
		{
			return Directory.GetFiles(s, "*" + CodeExplode.ExplodeFileType, SearchOption.AllDirectories).List().Select((s2) =>
			{
				return !s2.ToLower().Contains(CodeExploder.CodeExplodeLocation.ToLower());
			}).Convert(L.FileInfo_New);
		}).Cache("CodeExplode_FileInfoCache");
		#endregion
		#region MemberInfo_GetExplodedMembers
		public static Func<MemberInfo, List<MemberInfo>> MemberInfo_GetExplodedMembers = (Member) =>
		{
			Type MemberType = Member.DeclaringType;
			CodeExplode_ExplodeLogic ExplodeAttr = MemberType.MemberGetAttribute<CodeExplode_ExplodeLogic>(true);
			Type ExplodeType = ExplodeAttr.OutputType;
			if (ExplodeType != null)
				{
				List<MemberInfo> ExplodeTypeMembers = ExplodeType.GetMembers().List();
				return ExplodeTypeMembers.Select((m) =>
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
		public static List<String> DeclaredExtensionCache = new List<string>();
		public static String CodeRootLocation = "";
		public static String CodeExplodeLocation = "";

		private const String FileExtension = ".cs";

		private static Func<List<Type>> ExplodeTypeFunc = L.GetAssemblyTypesWithAttribute.Supply(typeof(CodeExplode))
			.Cache("CodeExplode_ExplodeTypes");

		private static Lists<String, String> _GlobalFindReplace;
		public static Lists<String, String> GlobalFindReplace
			{
			get
				{
				if (_GlobalFindReplace == null)
					{
					_GlobalFindReplace = new Lists<string, string>();
					_GlobalFindReplace.Add("/*A*/, ", "/*A*/");
					_GlobalFindReplace.Add("/*A,*/, ", "/*A,*/");
					_GlobalFindReplace.Add("/*,A*/, ", "/*,A*/");
					(1).To(16, (i) =>
					{
						(1).For(i+1, (j) =>
						{
							String ArgStr = new String[j].Fill("T").CollectI((i2, s) => { return s + (i2 + 1); }).Combine(", ");
							_GlobalFindReplace.Add("/*-T" + i + "*/<" + ArgStr + ">", "/*-T" + i + "*/");
							_GlobalFindReplace.Add("/*-T" + i + "*/<" + ArgStr + ", U>", "/*-T" + i + "*/<U>");
							_GlobalFindReplace.Add("/*-T" + i + "*/" + ArgStr + ", U", "/*-T" + i + "*/U");
							_GlobalFindReplace.Add("/*-T" + i + "*/" + ArgStr + ", ", "/*-T" + i + "*/");
							_GlobalFindReplace.Add("/*-T" + i + "*/" + ArgStr, "/*-T" + i + "*/");
							_GlobalFindReplace.Add("<" + ArgStr + ">/*-T" + i + "*/", "/*-T" + i + "*/");
							_GlobalFindReplace.Add("<" + ArgStr + ", U>/*-T" + i + "*/", "<U>/*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + ", /*-T" + i + "*/", "/*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + ", U/*-T" + i + "*/", "U/*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + "/*-T" + i + "*/", "/*-T" + i + "*/");
							String ArgStr3 = new String[j].Fill("o").CollectI((i2, s) => { return s + (i2 + 1); }).Combine(", ");
							_GlobalFindReplace.Add("/*-O" + i + "*/" + ArgStr3 + ", ", "/*-O" + i + "*/");
							_GlobalFindReplace.Add("/*-O" + i + "*/" + ArgStr3, "/*-O" + i + "*/");
							_GlobalFindReplace.Add(ArgStr3 + ", /*-O" + i + "*/", "/*-O" + i + "*/");
							_GlobalFindReplace.Add(ArgStr3 + "/*-O" + i + "*/", "/*-O" + i + "*/");
							return true;
						});
						(17).For(i, (j) =>
						{
							String ArgStr = new String[i].Fill("T").CollectI((i2, s) => { return s + (i2 + 1); }).Combine(", ");
							String ArgStr2 = new String[j - i].Fill("T").CollectI((i2, s) => { return s + (i + i2 + 1); }).Combine(", ");
							_GlobalFindReplace.Add("<" + ArgStr + ", " + ArgStr2 + ">/*-T" + i + "*/", "<" + ArgStr2 + ">/*-T" + i + "*/");
							_GlobalFindReplace.Add("<" + ArgStr + ", " + ArgStr2 + ", U>/*-T" + i + "*/", "<" + ArgStr2 + ", U>/*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + ", " + ArgStr2 + ", /*-T" + i + "*/", ArgStr2 + ", /*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + ", " + ArgStr2 + ", U/*-T" + i + "*/", ArgStr2 + ", U/*-T" + i + "*/");
							_GlobalFindReplace.Add(ArgStr + ", " + ArgStr2 + "/*-T" + i + "*/", ArgStr2 + "/*-T" + i + "*/");
							String ArgStr3 = new String[i].Fill("o").CollectI((i2, s) => { return s + (i2 + 1); }).Combine(", ");
							String ArgStr4 = new String[j - i].Fill("o").CollectI((i2, s) => { return s + (i + i2 + 1); }).Combine(", ");
							_GlobalFindReplace.Add(ArgStr3 + ", " + ArgStr4 + ", /*-O" + i + "*/", ArgStr4 + "/*-O" + i + "*/");
							_GlobalFindReplace.Add(ArgStr3 + ", " + ArgStr4 + "/*-O" + i + "*/", ArgStr4 + "/*-O" + i + "*/");
							return true;
						});
					});
					}
				return _GlobalFindReplace;
				}
			}
		public List<Type> ExplodeTypes
			{
			get
				{
				return ExplodeTypeFunc();
				}
			}

		public CodeExploder(String CodeRootDir = "", String CodeExplodeDir = "")
			{
			CodeRootLocation = CodeRootDir;
			CodeExplodeLocation = CodeExplodeDir;
			}
		public void BackupAllExplodeFiles()
			{
			ExplodeTypes.Each(BackupType);
			}
		public void BackupType(Type t)
			{
			if (!CodeRootLocation.IsEmpty())
				{
				List<CodeExplode> attrs = t.MemberGetAttributes<CodeExplode>(true);
				attrs.Each((attr) =>
				{
					String FileName = L.CombinePaths(CodeExplodeLocation, attr.CodeFileName + CodeExplode.ExplodeFileType);
					String Data = "/*\r\n" + L.GetFileContents(FileName).ByteArrayToString() + "\r\n*/";
					Data = CodeExplodeGenerics.RemoveGenericComments(Data);
					File.WriteAllText(FileName.Replace(CodeExplode.ExplodeFileType, CodeExplode.BackupSuffix + CodeExplode.ExplodeFileType), Data);
				});
				}
			}
		public String ExplodeAllTypes()
			{
			return ExplodeTypes.Convert<Type, String>(ExplodeType).Combine();
			}
		public String ExplodeType(Type t)
			{
			List<MemberInfo> Members = t.GetMembers().Select((m) => { return m.MemberHasAttribute(typeof(CodeExplodeMember), true); }).List();

			List<CodeExplode> attrs = t.MemberGetAttributes<CodeExplode>(true);

			return attrs.Convert((attr) =>
			{
				List<MemberInfo> temp = Members.Select(attr.ExplodeMember);
				Lists<String, MemberInfo> Members2 = new Lists<string, MemberInfo>(temp.Convert((m) => { return m.MemberGetAttribute<CodeExplodeMember>(true).MethodName; }), temp);

				String Out =
						L.Language_Using(UsingLibraries,
						L.Language_Namespace(
							L.Language_Class(
								L.Language_Region(
									attr.ExplodeCode(Members2),
								attr.CodeRegionTitle),
							attr.ClassName, true),
						attr.CodeNamespace));

				if (!CodeRootLocation.IsEmpty() && !Out.IsEmpty())
					{
					String FileName = L.CombinePaths(CodeExplodeLocation, attr.CodeFileName + CodeExplode.ExplodeFileType);
					//Out = CodeExplodeGenerics.RemoveGenericComments(Out);
					(0).To(GlobalFindReplace.List1.Count - 1, (i) =>
					{
						Out = Out.ReplaceAll(GlobalFindReplace.List1[i], GlobalFindReplace.List2[i]);
					});
					File.WriteAllText(FileName, Out);
					}
				return Out;
			}).Combine();
			}
		public String[] UsingLibraries
			{
			get
				{
				return new String[] { "System",
                "System.Collections.Generic",
                };
				}
			}
		private string GetTypeFileDirectory(Type t)
			{
			return L.CombinePaths(CodeExplodeLocation);
			}
		private string GetTypeFileName(Type t)
			{
			CodeExplode ce = t.MemberGetAttribute<CodeExplode>(true);
			return ce.CodeRegionTitle + "_Explode" + FileExtension;
			}
		}
	}