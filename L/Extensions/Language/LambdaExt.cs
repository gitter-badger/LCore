using System;
using LCore;
using System.Collections.Generic;
using LCore.ObjectExtensions;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace LCore
    {
    public partial class Logic
        {
        //TODO Nested Classes
        //TODO fix Base Class recognition

        public static Type[] AllLambdaTypes = L.Array(typeof(FieldInfo), typeof(PropertyInfo), typeof(MethodInfo), typeof(ConstructorInfo))();

        #region GetLambdas
        public static Func<Type, Type[], String> Type_GetLambdas = (t, FieldTypes) =>
        {
            Dictionary<String, String> Out = new Dictionary<String, String>();
            Func<KeyValuePair<String, String>, KeyValuePair<String, String>> IncrementFunctionNames = (o) =>
            {
                if (o.Value.StartsWith("/*"))
                    {
                    return new KeyValuePair<string, string>("/*" + o.Key + "*/", o.Value);
                    }

                int i = 1;
                while (Out.ContainsKey(i == 1 ? o.Key : o.Key + i)) { i++; }
                if (i > 1)
                    {
                    return new KeyValuePair<String, String>(o.Key + i,
                    o.Value.Replace(" " + o.Key + " =", " " + o.Key + i + " ="));
                    }
                return o;
            };

            if (FieldTypes.Contains(typeof(FieldInfo)))
                L.Type_GetFields(t).List()
                .Convert(FieldInfo_GetLambdaStrings)
                .Each((d) => { Out.Merge(d, IncrementFunctionNames); });
            if (FieldTypes.Contains(typeof(PropertyInfo)))
                L.Type_GetProperties(t).List()
                .Convert(PropertyInfo_GetLambdaStrings)
                .Each((d) => { Out.Merge(d, IncrementFunctionNames); });
            if (FieldTypes.Contains(typeof(MethodInfo)))
                L.Type_GetMethods(t)
                .Convert(MethodInfo_GetLambdaString.Supply2(t))
                .Each((d) => { Out.Merge(d, IncrementFunctionNames); });
            if (FieldTypes.Contains(typeof(ConstructorInfo)))
                L.Type_GetConstructors(t).List<MethodBase>()
                .Convert(MethodBase_GetLambdaString.Supply2(t))
                .Each((d) => { Out.Merge(d, IncrementFunctionNames); });

            String Out2 = "#region " + t.Name + "\n" +
                Out.Values.Combine('\n').ReplaceAll("\n\n", "\n") + "\n" +
                "#endregion";
            if (false)
                {
                Type[] Interfaces = t.GetInterfaces();
                Interfaces.Each((t2) => { Out2 += "\n" + t2.GetLambdas(AllLambdaTypes); });
                }
            return Out2;
        };
        #endregion
        #region GetAllLambdas
        public static Func<Type, String> Type_GetAllLambdas = Type_GetLambdas.Supply2(AllLambdaTypes);
        #endregion
        #region PropertyInfo
        public static Func<PropertyInfo, Dictionary<String, String>> PropertyInfo_GetLambdaStrings = (p) =>
        {
            Boolean Index = false;
            String MethodType = p.DeclaringType.Name;
            String FieldType = p.PropertyType.Name;
            String FieldName = p.Name;
            ParameterInfo IndexParameter = p.GetIndexParameters().First();
            if (IndexParameter != null)
                {
                Index = true;
                FieldName = "At";
                }

            String FunctionGetName = MethodType + "_Get" + FieldName;
            String FunctionSetName = MethodType + "_Set" + FieldName;
            String ObjName = MethodType.ToLower()[0].ToString();

            Dictionary<String, String> Out = new Dictionary<String, String>();
            try
                {
                MethodInfo Getter = p.GetGetMethod();
                Boolean IsStatic = Getter.IsStatic;
                if (!Getter.IsPublic)
                    throw new Exception();
                String GetFunction = "public static Func<" +
                    (!IsStatic || Index ? MethodType + ", " : "") +
                    (Index ? IndexParameter.ParameterType.Name + ", " : "") +
                    FieldType + "> " + FunctionGetName +
                    " = (" + (!IsStatic ? ObjName : "") + (Index ? ", index" : "") + ") => { " +
                    "return " + (!IsStatic || Index ? ObjName : MethodType) +
                    (Index ? "[index]" : "." + FieldName) + "; };";

                Out.Add(FunctionGetName, GetFunction);
                }
            catch { }
            try
                {
                MethodInfo Setter = p.GetSetMethod();
                Boolean IsStatic = Setter.IsStatic;
                if (!Setter.IsPublic)
                    throw new Exception();
                Out.Add(FunctionSetName, "public static Action<" +
                    (!IsStatic || Index ? MethodType + ", " : "") +
                    (Index ? IndexParameter.ParameterType.Name + ", " : "") +
                    FieldType + "> " + FunctionSetName +
                " = (" + ObjName + (Index ? ", index" : "") + ", " + FieldType.ToLower()[0] + ") => { " +
                (!IsStatic || Index ? ObjName : MethodType) +
                (Index ? "[index]" : "." + FieldName) +
                " = " + FieldType.ToLower()[0] + "; };");
                }
            catch { }
            return Out;
        };
        #endregion
        #region FieldInfo
        public static Func<FieldInfo, Dictionary<String, String>> FieldInfo_GetLambdaStrings = (f) =>
        {
            String MethodType = f.DeclaringType.Name;
            String FieldType = f.FieldType.Name;
            String FieldName = f.Name;
            String FunctionGetName = MethodType + "_Get" + FieldName;
            String FunctionSetName = MethodType + "_Set" + FieldName;
            Boolean IsConst = f.IsLiteral || f.IsInitOnly;
            String ObjName = MethodType.ToLower()[0].ToString();

            Dictionary<String, String> Out = new Dictionary<String, String>();
            Out.Add(FunctionGetName, "public static Func<" + (!IsConst ? MethodType + ", " : "") + FieldType + "> " + FunctionGetName +
                " = (" + (!IsConst ? ObjName + ", " : "") + ") => { return " + (!IsConst ? ObjName : MethodType) + "." + FieldName + "; };");
            if (!IsConst)
                Out.Add(FunctionSetName, "public static Action<" + MethodType + ", " + FieldType + "> " + FunctionSetName +
                    " = (" + ObjName + ", " + FieldType.ToLower()[0] + ") => { " + (IsConst ? ObjName : MethodType) + "." + FieldName + " = " + FieldType.ToLower()[0] + "; };");
            return Out;
        };
        #endregion
        #region MethodInfo
        public static Func<MethodBase, Type, Dictionary<String, String>> MethodBase_GetLambdaString = (m, t) =>
        {
            ParameterInfo[] Params = m.GetParameters();
            Boolean IsConstructor = m is ConstructorInfo;
            Type ReturnType = m is MethodInfo ? ((MethodInfo)m).ReturnType : IsConstructor ? ((ConstructorInfo)m).DeclaringType : typeof(void);
            String[] TypeNames = Params.Convert((p) => { return p.ParameterType.Name; });
            String[] ParamNames = Params.Convert((p) => { return p.Name; });
            String ReturnTypeStr = ReturnType.TypeEquals(typeof(void)) ? "" : ReturnType.Name;
            String MethodType = ReturnType.TypeEquals(typeof(void)) ? "Action" : "Func";
            String DeclaringType = m.DeclaringType.Name;
            String MethodName = m.Name;
            String FunctionName = DeclaringType + "_" + MethodName;

            if (MethodName.StartsWith("get_") ||
                MethodName.StartsWith("set_"))
                return new Dictionary<string, string>();
            String[] FunctionStrings = ParamNames;
            if (!m.IsStatic && !IsConstructor)
                {
                TypeNames = new[] {DeclaringType}.Add(TypeNames);
                DeclaringType = DeclaringType.ToLower()[0].ToString();
                ParamNames = new[] { DeclaringType }.Add(ParamNames);
                }

            if (!ReturnTypeStr.IsEmpty())
                TypeNames = TypeNames.Add(ReturnTypeStr);
            List<String> TempFound = new List<String>();
            String ParamString = ParamNames.Collect((s) =>
            {
                if (!TempFound.Contains(s))
                    return s;
                else
                    {
                        {
                        s = s + TempFound.Count(s.If()).ToString();
                        TempFound.Add(s);
                        return s;
                        }
                    }
            }).Combine(", ");
            TempFound = new List<String>();
            String FunctionString = FunctionStrings.Collect((s) =>
            {
                if (!TempFound.Contains(s))
                    return s;
                else
                    {
                    s = s + TempFound.Count(s.If()).ToString();
                    TempFound.Add(s);
                    return s;
                    }
            }).Combine(", ");

            String MethodAction = DeclaringType + "." + MethodName + "(" + FunctionString + ")";

            if (MethodName.StartsWith("op_"))
                {
                FunctionName = DeclaringType + "_" + L.Language_CleanOperationFunctionName(MethodName);
                MethodAction = FunctionString.Replace(",", L.Language_CleanOperationFunctionAction(MethodName));
                }
            else if (IsConstructor)
                {
                FunctionName = DeclaringType + "_New";
                MethodAction = "new " + DeclaringType + "(" + FunctionString + ")";
                }
            String Out = "public static " + MethodType;
            if (!TypeNames.IsEmpty())
                Out += "<" + TypeNames.Combine(", ") + ">";
            Out += " " + FunctionName + " = ";
            Out += "(";
            Out += ParamString;
            Out += ") => {";
            if (!ReturnTypeStr.IsEmpty())
                Out += " return ";
            Out += MethodAction;
            Out += "; };";

            Dictionary<String, String> Out2 = new Dictionary<String, String>();

            if (ParamNames.Count() > L.ParameterLimit)
                Out = "/* Too Many Parameters :( \n" +
                    Out + "\n*/";
            else if (!IsConstructor && !m.GetGenericArguments().IsEmpty() || Out.Contains('`'))
                Out = "/* No Generic Types \n" +
                    Out + "\n*/";
            else if (!m.DeclaringType.TypeEquals(t))
                Out = "/* Method found on base type \n" +
                    Out + "\n*/";
            else if (Out.Contains("&"))
                Out = "/* No Ref or Out Types \n" +
                    Out + "\n*/";

            Out2.Add(FunctionName, Out);
            return Out2;
        };
        public static Func<MethodInfo, Type, Dictionary<String, String>> MethodInfo_GetLambdaString = MethodBase_GetLambdaString;
        #endregion
        }
    public static class LambdaExt
        {
        public static String GetLambdas(this Type In, Type[] Types)
            {
            return L.Type_GetLambdas(In, Types);
            }
        public static String GetAllLambdas(this Type In)
            {
            return L.Type_GetAllLambdas(In);
            }
        public static String GetLambdas(this FieldInfo In, Type[] Types)
            {
            return L.FieldInfo_GetLambdaStrings(In).Keys.Combine('\n');
            }
        public static String GetLambdas(this PropertyInfo In, Type[] Types)
            {
            return L.PropertyInfo_GetLambdaStrings(In).Keys.Combine('\n');
            }
        public static String GetLambdas(this MethodBase In, Type[] Types)
            {
            return L.MethodBase_GetLambdaString(In, In.DeclaringType).Keys.Combine('\n');
            }
        }
    }