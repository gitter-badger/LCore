using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using LCore.Extensions;

namespace LCore.Tools
    {
    /// <summary>
    /// Extensions to Type and MemberInfo classes to allow seamless 
    /// gathering of XML comments directly from source code.
    /// 
    /// For the project you're analyzing you MUST check the 
    /// XML documentation option in Project Properties -> Build Tab
    /// </summary>
    public static class CommentExt
        {
        /// <summary>
        /// Returns an ICodeComment object representing the XML comments
        /// for a particular Type (class) if comments exist. Null otherwise.
        /// </summary>
        /// <param name="In">The Type to read comments</param>
        /// <returns>An ICodeComment object if comments exist. Null otherwise.</returns>
        public static ICodeComment GetComments(this Type In)
            {
            var a = Assembly.GetAssembly(In);

            string ProjectFolder = AppContext.BaseDirectory;

#if DEBUG
            string DocFile = L.File.CombinePaths(ProjectFolder, $"bin\\debug\\{a.GetName().Name}.xml");
#else
            String DocFile = L.File.CombinePaths(ProjectFolder, $"bin\\release\\{a.GetName().Name}.xml");
#endif

            if (File.Exists(DocFile))
                {
                var doc = new XmlDocument();
                doc.Load(DocFile);

                var MemberNodes = doc.SelectNodes("/members");

                string CommentName = GetCommentName(In);

                if (MemberNodes != null)
                    foreach (XmlNode MemberNode in MemberNodes)
                        {
                        if (!string.Equals(MemberNode.Attributes?["name"], CommentName))
                            continue;

                        var SummaryNode = MemberNode.SelectSingleNode("/summary");
                        //XmlNode ReturnsNode = MemberNode.SelectSingleNode("/returns");

                        var TypeParamNodes = MemberNode.SelectNodes("/typeparam");

                        string Summary = SummaryNode?.InnerText ?? "";
                        //string Returns = ReturnsNode?.InnerText ?? "";

                        var TypeParams = new Dictionary<string, string>();

                        if (TypeParamNodes != null)
                            foreach (XmlNode Node in TypeParamNodes)
                                {
                                if (Node.Attributes?["name"] != null)
                                    {
                                    string TypeName = Node.Attributes?["name"].Value;
                                    string TypeComments = Node.InnerText;

                                    TypeParams.Add(TypeName, TypeComments);
                                    }
                                }

                        var Out = new CodeComment
                            {
                            Summary = Summary,
                            //Returns = Returns,
                            TypeParams = TypeParams
                            };

                        return Out;
                        }
                }

            return null;
            }

        /// <summary>
        /// Returns an ICodeComment object representing the XML comments
        /// for a particular MemberInfo (Method, Property, or Field)
        /// if comments exist. Null otherwise.
        /// </summary>
        /// <param name="In">The MemberInfo to read comments</param>
        /// <returns>An ICodeComment object if comments exist. Null otherwise.</returns>
        public static ICodeComment GetComments(this MemberInfo In)
            {
            var a = Assembly.GetAssembly(In.DeclaringType);

            string ProjectFolder = AppContext.BaseDirectory;

#if DEBUG
            string DocFile = L.File.CombinePaths(ProjectFolder, $"bin\\debug\\{a.GetName().Name}.xml");
#else
            String DocFile = L.CombinePaths(ProjectFolder, $"bin\\release\\{a.GetName().Name}.xml");
#endif

            string CommentName = GetCommentName(In);

            if (File.Exists(DocFile))
                {
                var doc = new XmlDocument();
                doc.Load(DocFile);

                var MemberNodes = doc.SelectNodes("/members");

                if (MemberNodes != null)
                    foreach (XmlNode MemberNode in MemberNodes)
                        {
                        if (!string.Equals(MemberNode.Attributes?["name"], CommentName))
                            continue;

                        var SummaryNode = MemberNode.SelectSingleNode("/summary");
                        //XmlNode ReturnsNode = MemberNode.SelectSingleNode("/returns");

                        var TypeParamNodes = MemberNode.SelectNodes("/typeparam");

                        string Summary = SummaryNode?.InnerText ?? "";
                        //string Returns = ReturnsNode?.InnerText ?? "";

                        var TypeParams = new Dictionary<string, string>();

                        if (TypeParamNodes != null)
                            foreach (XmlNode Node in TypeParamNodes)
                                {
                                if (Node.Attributes?["name"] != null)
                                    {
                                    string TypeName = Node.Attributes?["name"].Value;
                                    string TypeComments = Node.InnerText;

                                    TypeParams.Add(TypeName, TypeComments);
                                    }
                                }

                        var Out = new CodeComment
                            {
                            Summary = Summary,
                            //Returns = Returns,
                            TypeParams = TypeParams
                            };

                        return Out;
                        }
                }

            return null;
            }

        private static string GetCommentName(this Type In)
            {
            const string Code = "T";

            return GetCommentName(Code, In.Namespace, In.Name, null, In.GetGenericArguments().Length);
            }

        private static string GetCommentName(this MemberInfo In)
            {
            string Code = "";

            if (In is MethodInfo)
                Code = "M";
            else if (In is FieldInfo)
                Code = "F";
            else if (In is PropertyInfo)
                Code = "P";

            return GetCommentName(Code, In.DeclaringType?.Namespace, In.DeclaringType?.Name, In.Name, (In as MethodInfo)?.GetGenericArguments().Length ?? 0);
            }

        private static string GetCommentName(string Code, string Namespace, string TypeName, string MemberName, int types)
            {
            string Out = $"{Code}:{Namespace}.{Namespace}.{TypeName}";

            if (!string.IsNullOrEmpty(MemberName))
                Out += $".{MemberName}";

            if (types > 0)
                Out += $"``{types}";

            return Out;
            }
        }
    }
