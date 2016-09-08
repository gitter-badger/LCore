using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Security;
using System.Xml;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Interfaces;
using LCore.Tools;

namespace LCore.Extensions
    {
    /// <summary>
    /// Extensions to Type and MemberInfo classes to allow seamless 
    /// gathering of XML comments directly from source code.
    /// 
    /// For the project you're analyzing you MUST check the 
    /// XML documentation option in Project Properties -> Build Tab
    /// </summary>
    [ExtensionProvider]
    public static class CommentExt
        {
        #region GetComments

        /// <summary>
        /// Returns an ICodeComment object representing the XML comments
        /// for a particular MemberInfo (Method, Property, or Field)
        /// if comments exist. Null otherwise.
        /// </summary>
        /// <param name="In">The MemberInfo to read comments</param>
        /// <returns>An ICodeComment object if comments exist. Null otherwise.</returns>
        [CanBeNull]
        public static ICodeComment GetComments([CanBeNull] this MemberInfo In)
            {
            var MemberNode = In.GetCommentNode();

            if (MemberNode != null)
                {
                var SummaryNode = MemberNode.SelectSingleNode(L.Comment.XmlTags.Summary);
                var RemarksNode = MemberNode.SelectSingleNode(L.Comment.XmlTags.Remarks);
                var ValueNode = MemberNode.SelectSingleNode(L.Comment.XmlTags.Value);
                string Returns = MemberNode.SelectSingleNode(L.Comment.XmlTags.Returns)?.InnerText;

                var TypeParamNodes = MemberNode.SelectNodes(L.Comment.XmlTags.TypeParam);
                var ExamplesParamNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Example);
                var ParamNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Param);
                var ExceptionNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Exception);
                var PermissionNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Permission);
                var IncludesNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Include);

                var FeatureNodes = MemberNode.SelectNodes(L.Comment.XmlTags.Feature);
                var ClassFeatureNodes = MemberNode.SelectNodes(L.Comment.XmlTags.ClassFeature);
                var ProjectFeatureNodes = MemberNode.SelectNodes(L.Comment.XmlTags.ProjectFeature);
                var TestedFeatureNodes = MemberNode.SelectNodes(L.Comment.XmlTags.TestedFeature);

                string Summary = SummaryNode?.InnerText ?? "";
                //string Returns = ReturnsNode?.InnerText ?? "";

                var TypeParameters = new List<Set<string, string>>();
                var Params = new List<Set<string, string>>();
                var Exceptions = new List<Set<string, string>>();
                var Permissions = new List<Set<string, string>>();
                var Includes = new List<Set<string, string>>();

                var Features = new List<string>();
                var ClassFeatures = new List<string>();
                var ProjectFeatures = new List<string>();
                var TestedFeatures = new List<string>();


                // ReSharper disable LoopCanBeConvertedToQuery
                if (TypeParamNodes != null)
                    foreach (XmlNode Node in TypeParamNodes)
                        {
                        if (Node.Attributes?[L.Comment.XmlTags.Name] != null)
                            {
                            string TypeName = Node.Attributes?[L.Comment.XmlTags.Name].Value;
                            string TypeComments = Node.InnerText;

                            TypeParameters.Add(new Set<string, string>(TypeName, TypeComments));
                            }
                        }

                if (IncludesNodes != null)
                    foreach (XmlNode Node in IncludesNodes)
                        {
                        if (Node.Attributes?[L.Comment.XmlTags.File] != null)
                            {
                            string TypeFile = Node.Attributes?[L.Comment.XmlTags.File].Value;
                            string TypePath = Node.Attributes?[L.Comment.XmlTags.Path].Value;

                            Includes.Add(new Set<string, string>(TypeFile, TypePath));
                            }
                        }

                var Examples = new List<string>();

                if (ExamplesParamNodes != null)
                    Examples.AddRange(ExamplesParamNodes.List<XmlNode>().Convert(Node => Node.InnerText));

                if (ExceptionNodes != null)
                    foreach (XmlNode Node in ExceptionNodes)
                        {
                        if (Node.Attributes?["cref"] != null)
                            {
                            string ParamCref = Node.Attributes?["cref"].Value;
                            string ParamDescription = Node.InnerText;

                            Exceptions.Add(new Set<string, string>(ParamCref, ParamDescription));
                            }
                        }

                if (ParamNodes != null)
                    foreach (XmlNode Node in ParamNodes)
                        {
                        if (Node.Attributes?[L.Comment.XmlTags.Name] != null)
                            {
                            string ParamName = Node.Attributes?[L.Comment.XmlTags.Name].Value;
                            string ParamDescription = Node.InnerText;

                            Params.Add(new Set<string, string>(ParamName, ParamDescription));
                            }
                        }

                if (PermissionNodes != null)
                    foreach (XmlNode Node in PermissionNodes)
                        {
                        if (Node.Attributes?[L.Comment.XmlTags.CRef] != null)
                            {
                            string PermissionCref = Node.Attributes?[L.Comment.XmlTags.CRef].Value;
                            string PermissionDescription = Node.InnerText;

                            Permissions.Add(new Set<string, string>(PermissionCref, PermissionDescription));
                            }
                        }

                if (FeatureNodes != null)
                    foreach (XmlNode Node in FeatureNodes)
                        {
                        Features.Add(Node.InnerText);
                        }
                if (ClassFeatureNodes != null)
                    foreach (XmlNode Node in ClassFeatureNodes)
                        {
                        ClassFeatures.Add(Node.InnerText);
                        }
                if (ProjectFeatureNodes != null)
                    foreach (XmlNode Node in ProjectFeatureNodes)
                        {
                        ProjectFeatures.Add(Node.InnerText);
                        }
                if (TestedFeatureNodes != null)
                    foreach (XmlNode Node in TestedFeatureNodes)
                        {
                        TestedFeatures.Add(Node.InnerText);
                        }

                // ReSharper restore LoopCanBeConvertedToQuery

                var Out = new CodeComment
                    {
                    Summary = Summary,
                    Returns = Returns,
                    Examples = Examples.Array(),
                    Parameters = Params.Array(),
                    Exceptions = Exceptions.ToArray(),
                    Permissions = Permissions.Array(),
                    TypeParameters = TypeParameters.ToArray(),
                    Includes = Includes.Array(),
                    Remarks = RemarksNode?.InnerText,
                    Value = ValueNode?.InnerText,
                    Features = Features.Array(),
                    ClassFeatures = ClassFeatures.Array(),
                    ProjectFeatures = ProjectFeatures.Array(),
                    TestedFeatures = TestedFeatures.Array()
                    };

                return Out;
                }
            return null;
            }

        #endregion

        #region Private Methods +
        [CanBeNull]
        private static XmlNode GetCommentNode([CanBeNull] this MemberInfo In)
            {
            if (In != null)
                {
                List<XmlNode> Nodes = In.GetCommentNodes();

                string CommentName = GetCommentName(In);

                if (_MemberCommentNodes.ContainsKey(CommentName))
                    return _MemberCommentNodes[CommentName];

                while (Nodes.Count > 0)
                    {
                    var MemberNode = Nodes[index: 0];

                    string TagName = MemberNode.Attributes?[L.Comment.XmlTags.Name].Value;

                    _MemberCommentNodes.SafeAdd(TagName, MemberNode);
                    Nodes.RemoveAt(index: 0);

                    if (string.Equals(MemberNode.Attributes?[L.Comment.XmlTags.Name].Value, CommentName))
                        {
                        return MemberNode;
                        }
                    }
                }

            return null;
            }

        private static string GetCommentName(this Type In)
            {
            const string Code = "T";

            return GetCommentName(Code,
                In.Namespace,
                In.GetNestedNames(),
                MemberName: null,
                Types: In.GetGenericArguments().Length);
            }

        private static string GetCommentName(this MethodBase In)
            {
            string Out = GetCommentName("M",
                In.DeclaringType?.Namespace,
                In.DeclaringType?.GetNestedNames(),
                In.Name,
                In.GetGenericArguments().Length);
            //  string Parameters = In.GetParameters().Convert(Param => Param.ParameterType.FullName).JoinLines(",");
            //  return $"{Out}({Parameters})";


            string Parameters = In.GetParameters().Convert(Param => Param.ParameterType.FullName).JoinLines(",");

            if (!string.IsNullOrEmpty(Parameters))
                Parameters = $"({Parameters})";

            return $"{Out}{Parameters}";
            }

        private static string GetCommentName(this FieldInfo In)
            {
            return GetCommentName("F",
                In.DeclaringType?.Namespace,
                In.DeclaringType?.GetNestedNames(),
                In.Name,
                Types: 0);
            }

        private static string GetCommentName(this PropertyInfo In)
            {
            return GetCommentName("P",
                In.DeclaringType?.Namespace,
                In.DeclaringType?.GetNestedNames(),
                In.Name,
                Types: 0);
            }

        private static string GetCommentName(this MemberInfo In)
            {
            var Type = In.GetType();

            while (Type != null && (Type.Name.StartsWith("Runtime") || Type.Name == "RtFieldInfo"))
                Type = Type.BaseType;

            switch (Type?.Name)
                {
                case nameof(PropertyInfo):
                    return ((PropertyInfo)In).GetCommentName();
                case nameof(FieldInfo):
                    return ((FieldInfo)In).GetCommentName();
                case nameof(MethodBase):
                    return ((MethodBase)In).GetCommentName();
                case nameof(MethodInfo):
                    return ((MethodInfo)In).GetCommentName();
                case nameof(TypeInfo):
                    return ((TypeInfo)In).GetCommentName();
                default:
                    return "";
                }
            }

        private static string GetCommentName(string Code, [CanBeNull]string Namespace, [CanBeNull]string TypeName, [CanBeNull]string MemberName,
            int Types)
            {
            string Out = $"{Code}:{Namespace}.{TypeName}";

            if (!string.IsNullOrEmpty(MemberName))
                Out += $".{MemberName}";

            if (Types > 0)
                Out += $"``{Types}";

            return Out;
            }

        private static readonly Dictionary<string, XmlNode> _MemberCommentNodes = new Dictionary<string, XmlNode>();

        private static List<XmlNode> GetCommentNodes(this MemberInfo In)
            {
            return new Func<MemberInfo, List<XmlNode>>(Member =>
                {
                    var Type = Member is Type
                        ? (Type)Member
                        : Member.ReflectedType;

                    if (Type != null)
                        {
                        var Assem = Assembly.GetAssembly(Type);

                        string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory;
                        string DocFile = ProjectFolder;

                        DocFile = !DocFile.EndsWith("\\bin\\Debug") && !DocFile.EndsWith("\\bin\\Release")
                            ? L.File.CombinePaths(ProjectFolder, $"bin\\{Assem.GetName().Name}.xml")
                            : L.File.CombinePaths(ProjectFolder, $"\\{Assem.GetName().Name}.xml");

                        if (File.Exists(DocFile))
                            {
                            var Doc = new XmlDocument();
                            Doc.Load(DocFile);

                            List<XmlNode> MemberNodes = Doc.SelectNodes("//member").List<XmlNode>();

                            return MemberNodes;
                            }
                        }
                    return new List<XmlNode>();
                }).Cache(nameof(CommentExt) + nameof(GetCommentNodes))(In);
            }

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains values and test members for CommentExt
        /// </summary>
        /// <feature>1</feature>
        /// <feature>a</feature>
        /// <classFeature>2</classFeature>
        /// <projectFeature>3</projectFeature>
        /// <testedFeature>4</testedFeature>
        public static class Comment
            {
            /// <summary>
            /// Contains test members for CommentExt
            /// </summary>
            [ExcludeFromCodeCoverage]
            public static class Test
                {
                /// <summary>
                /// Test class
                /// </summary>
                /// <remarks>Remark</remarks>
                /// <returns>Returns</returns>
                /// <param name="A">param1</param>
                /// <param name="B">param2</param>
                /// <example><code>some code</code></example>
                /// <example><c>more code</c></example>
                /// <exception cref="Exception">exception 1</exception>
                /// <exception cref="ArgumentException">exception 2</exception>
                /// <permission cref="PermissionSet">permission 1</permission>
                /// <permission cref="CodeAccessPermission">permission 2</permission>
                /// <typeparam name="T">Type</typeparam>
                /// <value>value</value>
                /// <feature>1</feature>
                /// <feature>a</feature>
                /// <classFeature>2</classFeature>
                /// <projectFeature>3</projectFeature>
                /// <testedFeature>4</testedFeature>
                // ReSharper disable once UnusedTypeParameter
                public static string TestMethod<T>(int A, string B)
                    {
                    return A + B;
                    }
#pragma warning disable 1589
                /// <include file='filepath' path='[@name="filename"]'/>
#pragma warning restore 1589
                // ReSharper disable once UnusedTypeParameter
                public static string TestMethod2<T>(int A, string B)
                    {
                    return A + B;
                    }

                /// <summary>
                /// TestProperty 
                /// </summary>
                /// <feature>1</feature>
                /// <feature>a</feature>
                /// <classFeature>2</classFeature>
                /// <projectFeature>3</projectFeature>
                /// <testedFeature>4</testedFeature>
                public static string TestProperty { get; set; }

                /// <summary>
                /// TestField
                /// </summary>
                /// <feature>1</feature>
                /// <feature>a</feature>
                /// <classFeature>2</classFeature>
                /// <projectFeature>3</projectFeature>
                /// <testedFeature>4</testedFeature>
                // ReSharper disable once UnassignedField.Global
                public static string TestField;
                }

            #region XmlTags

            internal static class XmlTags
                {
                internal static readonly string Summary = nameof(Summary).ToLower();
                internal static readonly string Remarks = nameof(Remarks).ToLower();
                internal static readonly string Name = nameof(Name).ToLower();
                internal static readonly string CRef = nameof(CRef).ToLower();
                internal static readonly string Value = nameof(Value).ToLower();
                internal static readonly string TypeParam = nameof(TypeParam).ToLower();
                internal static readonly string Returns = nameof(Returns).ToLower();
                internal static readonly string Example = nameof(Example).ToLower();
                internal static readonly string Param = nameof(Param).ToLower();
                internal static readonly string Exception = nameof(Exception).ToLower();
                internal static readonly string Permission = nameof(Permission).ToLower();
                internal static readonly string Include = nameof(Include).ToLower();
                internal static readonly string File = nameof(File).ToLower();
                internal static readonly string Path = nameof(Path).ToLower();

                internal static readonly string Feature = nameof(Feature).ToLower();
                internal static readonly string ClassFeature = "classFeature";
                internal static readonly string ProjectFeature = "projectFeature";
                internal static readonly string TestedFeature = "testedFeature";
                }

            #endregion
            }
        }
    }