using MemberSiteAppTests.Startup.Views;
using MemberSiteAppTests.UITests;
using MemberSiteAppTests.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemberSiteAppTests.UITests;

[TestClass]
public class MemberGuideTests : MemberSiteAppBaseTestClass
{
    [TestMethod]
    [TestTraits(TestTrait.MemberGuide, TestTrait.Regression)]
    [DataRow("cataldke", DisplayName = "cataldke")]
    [DataRow("bernbern", DisplayName = "bernbern")]
    public void TC_Verify_MemberGuide_All_Chapter_Blocks(string user)
    {
        WebStartupView
            .GetSpecifiedUser(out var member, user)
            .StartWebApplication<HomeView>(member)
            .ClickOnCoverageAndBenefitsFromMenu()
            .ClickOnMemberGuide();

        // get the view instance and settings
        var memberGuideView = MemberGuideView
            .GetMemberGuideSettings(out var settings)
            .ValidateMemberGuideBanner(settings, Sa)
            .ValidateBannerComponents(settings, Sa)
            .GetSelectWelcomeDropdownOption(out List<string> welcomeDropdownOptions)
            .ValidateChapterBlocks(welcomeDropdownOptions, settings, Sa)
            .ValidateChapterListItems(welcomeDropdownOptions, Sa)
            //    .ValidateWelcomeDropdownOptions(settings, Sa)
            //.ValidateChapterBlocks(settings, Sa)
            //.ValidateChapterListItems(settings, Sa)
            .ValidateChapterSubheaderExternalLinks(Sa);
            ;
            .ValidateChapterSubheaderLinksByType(Sa);

        // validate each left block defined in settings using the view instance
        //foreach (var left in welcomeDropdownOptions)
        //{
        //    memberGuideView.ValidateChapterBlockByLeftText(left, settings, Sa);
        //}
        foreach (var left in welcomeDropdownOptions)
        {
            memberGuideView.ValidateChapterBlockByLeftText(left, settings, Sa);
        }
    }
}
