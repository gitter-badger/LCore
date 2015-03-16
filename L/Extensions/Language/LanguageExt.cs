using System;
using LCore;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;

namespace LCore
	{
	public partial class L : Logic
		{
		#region GetAssemblyTypes
		public static Func<List<Type>> GetAssemblyTypes = GetAssemblyTypesWithAttribute.Supply(typeof(void));
		#endregion
		#region Language_RemoveTypeNamespaces
		public static Func<String, String> Language_RemoveTypeNamespaces = (s) =>
			{
                while (s.Has('.'))
					{
					int index = s.IndexOf('.');
					String temp = s.Substring(0, index);
					int indexspace = temp.LastIndexOfAny(L.Language_SeparatorChars);
					if (indexspace < 0)
						{
						s = s.Substring(index + 1);
						}
					else
						{
						s = s.Substring(0, indexspace + 1) + s.Substring(index + 1);
						}
					}
				return s;
			};
		#endregion
		#region Language_CleanGenericTypeName
		public static Func<String, String> Language_CleanGenericTypeName = (s) =>
		{
			s = s.Replace("`1[", "<");
			s = s.Replace("`2[", "<");
			s = s.Replace("`3[", "<");
			s = s.Replace("`4[", "<");
			s = s.Replace("`5[", "<");
			s = s.Replace("`6[", "<");
			s = s.Replace("`7[", "<");
			s = s.Replace("`8[", "<");
			s = s.Replace("`9[", "<");
			s = s.Replace("`10[", "<");
			s = s.Replace("`11[", "<");
			s = s.Replace("`12[", "<");
			s = s.Replace("`13[", "<");
			s = s.Replace("`14[", "<");
			s = s.Replace("`15[", "<");
			s = s.Replace("`16[", "<");
			s = s.Replace("`17[", "<");
			s = s.Replace("Action`10", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>");
			s = s.Replace("Action`11", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>");
			s = s.Replace("Action`12", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>");
			s = s.Replace("Action`13", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>");
			s = s.Replace("Action`14", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>");
			s = s.Replace("Action`15", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>");
			s = s.Replace("Action`16", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>");
			s = s.Replace("Action`1", "Action<T1>");
			s = s.Replace("Action`2", "Action<T1,T2>");
			s = s.Replace("Action`3", "Action<T1,T2,T3>");
			s = s.Replace("Action`4", "Action<T1,T2,T3,T4>");
			s = s.Replace("Action`5", "Action<T1,T2,T3,T4,T5>");
			s = s.Replace("Action`6", "Action<T1,T2,T3,T4,T5,T6>");
			s = s.Replace("Action`7", "Action<T1,T2,T3,T4,T5,T6,T7>");
			s = s.Replace("Action`8", "Action<T1,T2,T3,T4,T5,T6,T7,T8>");
			s = s.Replace("Action`9", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9>");
			s = s.Replace("Func`10", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,U>");
			s = s.Replace("Func`11", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,U>");
			s = s.Replace("Func`12", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,U>");
			s = s.Replace("Func`13", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,U>");
			s = s.Replace("Func`14", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,U>");
			s = s.Replace("Func`15", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,U>");
			s = s.Replace("Func`16", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,U>");
			s = s.Replace("Func`17", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,U>");
			s = s.Replace("Func`1", "Func<U>");
			s = s.Replace("Func`2", "Func<T1,U>");
			s = s.Replace("Func`3", "Func<T1,T2,U>");
			s = s.Replace("Func`4", "Func<T1,T2,T3,U>");
			s = s.Replace("Func`5", "Func<T1,T2,T3,T4,U>");
			s = s.Replace("Func`6", "Func<T1,T2,T3,T4,T5,U>");
			s = s.Replace("Func`7", "Func<T1,T2,T3,T4,T5,T6,U>");
			s = s.Replace("Func`8", "Func<T1,T2,T3,T4,T5,T6,T7,U>");
			s = s.Replace("Func`9", "Func<T1,T2,T3,T4,T5,T6,T7,T8,U>");
			s = s.Replace("[]", "***");
			s = s.Replace("]", ">");
			s = s.Replace("[", ">");
			s = s.Replace("***", "[]");
			return L.Language_RemoveTypeNamespaces(s);
		};
		#endregion

		}
	public partial class Logic
		{
		public static String[] GenericInputTypes = new String[] { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16" };
		public static String[] GenericOutputTypes = new String[] { "U" };
		public static String[] GenericTypes = new String[] { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16", "U" };
		public static String[] Language_OpenSequences = new String[] { "[", "{", "(", "<", "\'", "\"", "/*", "//" };
		public static String[] Language_CloseSequences = new String[] { "]", "}", ")", ">", "\'", "\"", "*/", "\r\n" };
		public static Char[] Language_SeparatorChars = new Char[] { ' ', ',', '<', '>', '(', ')', '{', '}', '[', ']', '-', '+', '.', '/', '*', '-', '&', '^', '%', '=', '?' };

		#region GetAssemblyTypesWithAttribute
		public static Func<Type, List<Type>> GetAssemblyTypesWithAttribute = (attr) =>
		{
			return System.Reflection.Assembly.GetCallingAssembly().GetModules()
				.Convert((mod) => { return mod.GetTypes().Select((t) => { return attr.TypeEquals(typeof(void)) || t.MemberHasAttribute(attr, true); }); })
				.Flatten<Type>();
		};
		#endregion
		#region Language_ReplaceNativeTypes
		public static Func<String, String> Language_ReplaceNativeTypes = (s) =>
		{
			s = s.Replace("System.Double", "double");
			s = s.Replace("System.UInt32", "uint");
			s = s.Replace("System.Int32", "int");
			s = s.Replace("System.Single", "float");
			s = s.Replace("System.Boolean", "bool");
			s = s.Replace("Double", "double");
			s = s.Replace("UInt32", "uint");
			s = s.Replace("Int32", "int");
			s = s.Replace("Single", "float");
			s = s.Replace("Boolean", "bool");
			return s;
		};
		#endregion
		#region Language_CleanReservedWords
		public static Func<String, String> Language_CleanReservedWords = L.F<String, String>()
			.Case("double", "dbl")
			.Case("add", "a")
			.Case("alias", "a")
			.Case("ascending", "asc")
			.Case("descending", "desc")
			.Case("dynamic", "dyn")
			.Case("from", "f")
			.Case("get", "g")
			.Case("global", "gl")
			.Case("group", "gr")
			.Case("into", "i")
			.Case("join", "j")
			.Case("let", "l")
			.Case("orderby", "o")
			.Case("partial", "p")
			.Case("remove", "rem")
			.Case("select", "sel")
			.Case("set", "s")
			.Case("value", "v")
			.Case("var", "v")
			.Case("where", "w")
			.Case("yield", "y")
			.Case("abstract", "abs")
			.Case("as", "a")
			.Case("base", "b")
			.Case("bool", "b")
			.Case("break", "b")
			.Case("byte", "b")
			.Case("case", "c")
			.Case("catch", "c")
			.Case("char", "c")
			.Case("checked", "c")
			.Case("class", "c")
			.Case("const", "c")
			.Case("continue", "c")
			.Case("decimal", "d")
			.Case("default", "d")
			.Case("delegate", "d")
			.Case("do", "d")
			.Case("double", "d")
			.Case("else", "e")
			.Case("enum", "en")
			.Case("event", "ev")
			.Case("explicit", "exp")
			.Case("extern", "ext")
			.Case("false", "f")
			.Case("finally", "f")
			.Case("fixed", "f")
			.Case("float", "f")
			.Case("for", "f")
			.Case("foreach", "f")
			.Case("goto", "g")
			.Case("if", "i")
			.Case("implicit", "i")
			.Case("in", "i")
			.Case("int", "i")
			.Case("interface", "i")
			.Case("internal", "i")
			.Case("is", "i")
			.Case("lock", "l")
			.Case("long", "l")
			.Case("namespace", "n")
			.Case("new", "n")
			.Case("null", "n")
			.Case("object", "o")
			.Case("operator", "o")
			.Case("out", "o")
			.Case("override", "o")
			.Case("params", "p")
			.Case("private", "p")
			.Case("protected", "p")
			.Case("public", "p")
			.Case("readonly", "r")
			.Case("ref", "r")
			.Case("return", "r")
			.Case("sbyte", "s")
			.Case("sealed", "s")
			.Case("short", "s")
			.Case("sizeof", "s")
			.Case("stackalloc", "s")
			.Case("static", "s")
			.Case("string", "str")
			.Case("struct", "str")
			.Case("switch", "sw")
			.Case("this", "t")
			.Case("throw", "t")
			.Case("true", "t")
			.Case("try", "t")
			.Case("typeof", "t")
			.Case("uint", "u")
			.Case("ulong", "u")
			.Case("unchecked", "u")
			.Case("unsafe", "u")
			.Case("ushort", "u")
			.Case("using", "u")
			.Case("virtual", "v")
			.Case("void", "v")
			.Case("volatile", "v")
			.Case("while", "w")
			.Else(L.Pass<String>());
		#endregion
		#region Language_CommentSummary
		public static Func<String, String> Language_CommentSummary = (In) =>
		{
			return In.Replace("\r\n", "\r\n/// ").Surround("/// <summary>\r\n/// ",
					"\r\n/// </summary>\r\n");
		};
		#endregion
		#region Language_Class
		public static Func<String, String, Boolean, String> Language_Class = (In, ClassName, Static) =>
		{
			return In.Surround("public " + (Static ? "static " : "") + "class " + ClassName + "\r\n{\r\n",
				"}\r\n");
		};
		#endregion
		#region Language_Using
		public static Func<String[], String, String> Language_Using = (Usings, In) =>
		{
			if (Usings.IsEmpty() || In.IsEmpty())
				return In;

			String Out = "";
			Usings.Each((str) =>
			{
				Out += "using " + str + ";\r\n";
			});
			Out += "\r\n";
			Out += In;
			return Out;
		};

		#endregion
		#region Language_Namespace
		public static Func<String, String, String> Language_Namespace = (In, NamespaceName) =>
		{
			return In.Surround("namespace " + NamespaceName + "\r\n{\r\n",
					"}\r\n");
		};
		#endregion
		#region Language_Region
		public static Func<String, String, String> Language_Region = (In, Region) =>
			{
				return In.Surround("#region " + Region + "\r\n",
					"#endregion\r\n");
			};
		#endregion
		#region Language_GetGenericsFromTypes
		public static Func<String[], List<String>> Language_GetGenericsFromTypes = (Generics) =>
			{
				List<String> Out = new List<String>();
				Generics.Each((g) =>
				{
					Out.AddRange(L.Language_GetTypeGenerics(g));
				});

				Out = Out.RemoveDuplicates();
                Out = Out.Select<String>((s) => { return L.GenericTypes.Has(s); }).List();
				Out.Sort(L.String_NumericalCompare);
				return Out;
			};
		#endregion
		#region Language_GetTypeGenerics
		public static Func<String, List<String>> Language_GetTypeGenerics = (TypeStr) =>
		{
            string Out = (TypeStr.Has('<') ? TypeStr.Substring(TypeStr.LastIndexOf('<') + 1, TypeStr.LastIndexOf('>') - TypeStr.LastIndexOf('<') - 1) : "");
            if (Out.Has(','))
				return Out.Split(',').List().Collect((s) =>
					{
						if (s == "T")
							return "T1";
						if (s == "")
							return null;
						return s.Trim();
					});
			else if (!Out.IsEmpty())
				{
				return new List<String> { Out };
				}

			return new List<string>();
		};
		#endregion
		#region Language_GetEmptyTypeLambdaMethods
		public static Func<Type, String> Language_GetEmptyTypeLambdaMethods = (Type) =>
			{
				MethodInfo[] Methods = Type.GetMethods();
				return Methods.Convert(L.Language_GetEmptyLambdaFromMethod).Combine();
			};
		#endregion
		#region Language_GetEmptyLambdaFromMethod
		public static Func<MethodInfo, String> Language_GetEmptyLambdaFromMethod = (Method) =>
			{
				String Out = "";
				String FunctionTypeName = L.Language_CleanGenericTypeName(Method.ReturnType.ToString());
				String ParameterTypes = Method.GetParameters().Convert((p) => { return L.Language_CleanGenericTypeName(p.ParameterType.ToString()); }).Combine(", ");
				String ParameterNames = Method.GetParameters().Convert(L.ParameterInfo_GetName).Combine(",  ");
				List<String> Generics = L.Language_GetGenericsFromTypes(ParameterTypes.Split(",  ").Add(FunctionTypeName));
				Boolean ReadOnly = Generics.IsEmpty();
				String BaseType = (Method.ReturnType.TypeEquals(typeof(void)) ? "Action" : "Func");
				if (!ParameterTypes.IsEmpty())
					BaseType += "<" + ParameterTypes;
				if (!Method.ReturnType.TypeEquals(typeof(void)))
					BaseType += ", " + L.Language_CleanGenericTypeName(Method.ReturnType.ToString());
				BaseType += ">";

				Out = "public static " + (ReadOnly ? "readonly " : "");
				Out += BaseType + " ";
				Out += Method.Name;
				if (!ReadOnly)
					{
					Out += "<" + Generics.Combine(", ") + ">";
					Out += "()\r\n";
					Out += "{\r\n";
					Out += "return ";
					}
				else
					{
					Out += " = ";
					}
				Out += "(" + ParameterNames + ") => \r\n";
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
		#region Language_GetExtensionMethodDeclaration
		public static Func<String, Lists<String, Type>, Type, String, MemberTypes, Boolean, String> Language_GetExtensionMethodDeclaration = (Name, Params, OutType, Comment, MemberType, ExecuteResult) =>
		{
			if (Params.List1.Count == 0 ||
				Params.List2.Count == 0)
				throw new ArgumentException("No Parameters found");
			String FunctionTypeName = L.Language_CleanGenericTypeName(OutType.ToString());
			String ExtensionParam = L.Language_CleanGenericTypeName(Params.List2[0].ToString());
			String Parameters = "";
			if (Params.Count > 1)
				Parameters = (1).To(Params.Count - 1, (i) => { return L.Language_CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

			List<String> Generics = L.Language_GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

			String Out = "public static " + (ExecuteResult ? "void " : FunctionTypeName);
			Out += " " + Name;


			if (!Generics.IsEmpty())
				{
				Out += "<" + Generics.Combine(", ") + ">";
				}

			Out += "(this " + ExtensionParam + " " + Params.List1[0];
			if (Params.Count > 1)
				{
				Out += ", ";
				(1).For(Params.Count, (i) =>
				{
					String ParamType = L.Language_CleanGenericTypeName(Params.List2[i].ToString());
					if (Params.List1[i].StartsWith("params"))
						{
						Out += "params ";
						Params.Set(i, Params.List1[i].Substring(7));
						}
					Out += ParamType + " " + Params.List1[i];
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
				Out = L.Language_CommentSummary(Comment) + Out;
			return Out;
		};
		#endregion
		#region Language_GetExtensionMethodBody
		public static Func<Type, String, Lists<String, Type>, Type, MemberTypes, Boolean, String> Language_GetExtensionMethodBody = (DeclaringType, Name, Params, ReturnType, MemberType, ExecuteResult) =>
		{

			String ExtensionParam = L.Language_CleanGenericTypeName(Params.List2[0].ToString());
			String Parameters = "";
			if (Params.Count > 1)
				Parameters = (1).To(Params.Count - 1, (i) => { return L.Language_CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

			String FunctionTypeName = L.Language_CleanGenericTypeName(ReturnType.ToString());
			List<String> Generics = L.Language_GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

			String Out = "{\r\n";
			Out += (!ReturnType.TypeEquals(typeof(void)) && !ExecuteResult ? "return " : "") + DeclaringType.Name + "." + Name;

			if (!Generics.IsEmpty())
				{
				Out += "<" + Generics.Combine(", ") + ">";
				}

			Out += (MemberType.HasFlag(MemberTypes.Method) ? "()" : "") + "(" +
				Params.List1.List().Collect((s) => { if (s.Contains(" = ")) s = s.Substring(0, s.IndexOf(" = ")); return s; })
				.Combine(", ") + ")";
			if (ExecuteResult)
				Out += "()";
			Out += ";\r\n";

			Out += "}\r\n";
			return Out;
		};
		#endregion
		}
	}