using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Interfaces;
using LMVC;
using LMVC.Extensions;
using Xunit;
using Xunit.Sdk;

namespace L_MVC_Tests.Layouts
    {
    public class SingularityTest
        {
        [Fact]
        public void SingularityHasAppName()
            {
            Singularity.AppName.Should().Be("Singularity");
            }

        [Fact]
        public void SingularityHasLIcons()
            {

            List<Type> L_Icons = Singularity.Icons.TypeIcons_L.Keys.List();
            L_Icons.Sort(i => i.Name);

            List<Type> Types = L.Ref.GetNamespaceTypes(typeof(L), "LCore.Extensions", typeof(IExtensionProvider)).List();
            Types.Sort(i => i.Name);

            L_Icons.Should().BeEquivalentTo(Types);
            }

        [Fact]
        public void SingularityHasLMVCIcons()
            {
            List<Type> LMVC_Icons = Singularity.Icons.TypeIcons_LMVC.Keys.List();
            LMVC_Icons.Sort(i => i.Name);

            List<Type> Types = L.Ref.GetNamespaceTypes(typeof(Singularity), "LMVC.Extensions", typeof(IExtensionProvider)).List();
            Types.Sort(i => i.Name);

            LMVC_Icons.Should().BeEquivalentTo(Types);
            }

        [Fact]
        public void Singularity_GetTypeIcon()
            {
            Singularity.Icons.GetTypeIcon(null).Should().BeNull();
            Singularity.Icons.GetTypeIcon(typeof(L)).Should().NotBeNull().And.NotBe(FontAwesomeExt.Icon.question);
            Singularity.Icons.GetTypeIcon(typeof(UrlExt)).Should().NotBeNull().And.NotBe(FontAwesomeExt.Icon.question);
            Singularity.Icons.GetTypeIcon(typeof(string)).Should().NotBeNull().And.NotBe(FontAwesomeExt.Icon.question);
            Singularity.Icons.GetTypeIcon(typeof(SourceInformation)).Should().Be(FontAwesomeExt.Icon.question);
            }
        }
    }
