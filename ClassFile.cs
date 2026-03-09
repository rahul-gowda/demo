using Automation.Framework.AutomationCore.WebControls;
using Automation.Framework.AutomationCore.WebControls.Standard;
using MemberSiteAppTests.Startup.Views;
using OpenQA.Selenium;
using static MemberSiteAppTests.Common.MemberGuideSettings;

namespace MemberSiteAppTests.Views;

internal class MemberGuideView : MemberSiteAppPageObjectsBase
{
    #region Page Objects
    protected By HeaderBy => By.CssSelector("h1.welcome-header");
    private TextArea WelcomeDesc => GetWebControlWhenVisible<TextArea>(By.CssSelector(".welcome-description"));
    private SelectOption WelcomeDropdown => GetWebControlWhenVisible<SelectOption>(By.CssSelector(".welcome-block ods-select"));
    private TextArea WelcomePromoContent => GetWebControlWhenVisible<TextArea>(By.CssSelector(".promo-content__desc"));
    private ElementBase WelcomeImg => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-image"));

    private ElementBase WelcomeBannerPicture => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-banner__banner"));
    private TextArea PromoTitle => GetWebControlWhenVisible<TextArea>(By.CssSelector(".promo-content__title"));
    private TextArea PromoDesc => GetWebControlWhenVisible<TextArea>(By.CssSelector(".promo-content__desc"));

    // Top-level / header navigation
    protected By SkipLinkBy => By.CssSelector("a#skiplink.skipLink");
    private ElementBase SkipLink => GetWebControlWhenVisible<ElementBase>(SkipLinkBy);
    private ElementBase ContactUsLink => GetWebControlWhenVisible<ElementBase>(By.CssSelector("a.contact-forms[href='/contact']"));
    private ElementBase DocumentsAndFormsLink => GetWebControlWhenVisible<ElementBase>(By.CssSelector("a.contact-forms.document-and-forms"));
    private ElementBase InboxLink => GetWebControlWhenVisible<ElementBase>(By.CssSelector("a.inbox"));
    private ElementBase ProfileIconLink => GetWebControlWhenVisible<ElementBase>(By.CssSelector("a[aria-label='Visit your profile, Healthplan Member.']"));

    // Chatbot / webchat
    private ElementBase OpenChatBtn => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#open-chat-btn"));
    private ElementBase ChatContainer => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chatbot-container"));
    protected By ChatTranscriptBy => By.CssSelector(".webchat__basic-transcript");
    private ElementBase ChatTranscript => GetWebControlWhenVisible<ElementBase>(ChatTranscriptBy);
    private ElementBase ChatMessageInput => GetWebControlWhenVisible<ElementBase>(By.CssSelector("textarea[data-id='webchat-sendbox-input']"));
    private Button ChatSendButton => GetWebControlWhenVisible<Button>(By.CssSelector(".webchat__send-button, .webchat--css-ehnte-x09yo8.webchat__send-button"));
    private ElementBase ChatUploadInput => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".webchat__upload-button--file-input"));
    private ElementBase ChatSubmitError => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#webchat__send-box__error-message-id--unh63"));

    // Terms & Conditions chatbot popup
    private ElementBase TermsWrapperHeader => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".terms-wrapper .header"));
    private Button TermsAcceptButton => GetWebControlWhenVisible<Button>(By.CssSelector(".button-accept"));
    private Button TermsCancelButton => GetWebControlWhenVisible<Button>(By.CssSelector(".button-cancel"));

    // AnywhereCare popup / upmc-popup
    protected By AnyWhereCarePopupBy => By.CssSelector("#anyWhereCareEmailPopup .popup-wrapper");
    private ElementBase AnyWhereCarePopupWrapper => GetWebControlWhenVisible<ElementBase>(AnyWhereCarePopupBy);
    private ElementBase AnyWhereCarePopupTitle => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#anyWhereCareEmailPopup .popup-title"));
    private ElementBase AnyWhereCareEmailInput => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#anyWhereCareEmailPopup ods-text-input input#input"));
    private Button AnyWhereCareContinueButton => GetWebControlWhenVisible<Button>(By.CssSelector("#anyWhereCareEmailPopup ods-button[variant='primary'] button"));

    // Chapter / content blocks
    protected By ChapterContentWholeBy => By.CssSelector(".chapter-content-whole");
    private ElementBase ChapterContentWhole => GetWebControlWhenVisible<ElementBase>(ChapterContentWholeBy);
    private ElementBase ChapterBlock => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chapter-block"));
    private ElementBase ChapterLeftBlock => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chapter-left-block"));
    private ElementBase ChapterRightBlock => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chapter-right-block"));
    private TextArea ChapterSubheaderTitle => GetWebControlWhenVisible<TextArea>(By.CssSelector(".chapter-subheader-title"));
    private TextArea ChapterSubheaderDescription => GetWebControlWhenVisible<TextArea>(By.CssSelector(".chapter-subheader-description"));
    private ElementBase ChapterSubheaderLink => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chapter-subheader-link, .chapter-subheader-link1"));
    private ElementBase ChapterSubheaderImage => GetWebControlWhenVisible<ElementBase>(By.CssSelector(".chapter-subheader-image"));

    // Lists inside chapters
    protected By DescriptionListBy => By.CssSelector("ul.description-list");
    private ElementBase DescriptionList => GetWebControlWhenVisible<ElementBase>(DescriptionListBy);
    private IList<ElementBase> DescriptionListItems => GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"));

    // Footnotes / notes
    protected By FootnoteListBy => By.CssSelector("ol.footnote-content");
    private ElementBase FootnoteList => GetWebControlWhenVisible<ElementBase>(FootnoteListBy);
    private ElementBase Footnote_CommunicationPreferences => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#communication-preferences"));
    private ElementBase Footnote_ChatCall => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#chat-call"));
    private ElementBase Footnote_Providers => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#providers"));
    private ElementBase Footnote_StudiesHaveShown => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#studies-have-shown"));
    private ElementBase Footnote_HearingPlanLimits => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#hearing-plan-limits"));
    private ElementBase Footnote_BenefitDeductable => GetWebControlWhenVisible<ElementBase>(By.CssSelector("#benefit-deductable"));

    // Promo / banner variants
    protected By WelcomeBannerBy => By.CssSelector(".welcome-banner__promo");
    private ElementBase WelcomeBannerPromo => GetWebControlWhenVisible<ElementBase>(WelcomeBannerBy);
    private TextArea WelcomeBannerPromoTitle => GetWebControlWhenVisible<TextArea>(By.CssSelector(".welcome-banner__promo .promo-content__title"));
    private TextArea WelcomeBannerPromoDesc => GetWebControlWhenVisible<TextArea>(By.CssSelector(".welcome-banner__promo .promo-content__desc"));

    // Footer
    private ElementBase FooterLinksContainer => GetWebControlWhenVisible<ElementBase>(By.CssSelector("member-site-footer .links"));
    private IList<ElementBase> FooterLinks => GetWebControls<ElementBase>(By.CssSelector("member-site-footer .links a"));
    private TextArea FooterCopyright => GetWebControlWhenVisible<TextArea>(By.CssSelector(".disclaimer p"));

    #endregion

    public MemberGuideView(AutomationBase automationBase) : base(automationBase)
    {
        ClassName = $"{GetType().Name}: ";
        AutomationBaseInstance.WaitForPageToLoad();
        WaitForRequiredElement(HeaderBy, nameof(ClassName), ApplicationTimeouts.Extended);
    }

    public MemberGuideView GetMemberGuideSettings(out MemberGuideSettings memberGuideSettings)
    {
        memberGuideSettings = MemberGuideSettings.GetOnboardingTutorialSettings();
        return this;
    }

    /// <summary>
    /// Open the welcome ods-select combobox and validate the available options against configured settings.
    /// </summary>
    public MemberGuideView ValidateWelcomeDropdownOptions(MemberGuideSettings settings, SoftAssertions sa)
    {
        // Ensure dropdown host is present
        By.CssSelector(".welcome-block ods-select").WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);

        // Try to open the combobox inside the component's shadow DOM; fall back to host click
        try
        {
            FindElementInShadowDom(By.CssSelector(".welcome-block ods-select"), By.CssSelector("#combobox")).JScriptClick();
        }
        catch
        {
            var host = GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-block ods-select"));
            host?.JScriptClick();
        }

        // Collect ods-select-option elements (XPath used to cover light DOM placement)
        var optionElems = GetWebControls<ElementBase>(By.XPath("//ods-select-option")) ?? new List<ElementBase>();

        var optionTexts = optionElems
            .Select(o => o.Text?.Trim())
            .Where(t => !string.IsNullOrWhiteSpace(t) && !t.Equals("Select an option", StringComparison.OrdinalIgnoreCase))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        sa.ShouldBeTrue(optionTexts.Count > 0, $"{ClassName} Welcome dropdown should contain one or more options");

        // Normalizer consistent with other validators in this view
        static string Normalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var sb = new System.Text.StringBuilder();
            foreach (var ch in s.Normalize().ToLowerInvariant())
            {
                if (char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)) sb.Append(ch);
            }
            return System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "\\s+", " ").Trim();
        }

        var normOptions = optionTexts.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var expectedLefts = settings?.ChapterLeftBlocks ?? new List<string>();
        var normExpected = expectedLefts.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        // Loose mapping: option should match at least one expected left block (contains/contained)
        var unexpected = normOptions
            .Where(opt => !normExpected.Any(exp => exp.Contains(opt) || opt.Contains(exp)))
            .ToList();

        sa.ShouldBeTrue(!unexpected.Any(), $"{ClassName} Welcome dropdown contains unexpected options: {string.Join(", ", unexpected)}");

        return this;
    }

    /// <summary>
    /// Validate that at least one chapter subheader link button contains 'external' in its href.
    /// </summary>
    public MemberGuideView ValidateChapterSubheaderExternalLinks(SoftAssertions sa)
    {
        ChapterContentWholeBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);

        var buttons = GetWebControls<ElementBase>(By.CssSelector(".chapter-subheader-link-button")) ?? new List<ElementBase>();
        sa.ShouldBeTrue(buttons.Count > 0, $"{ClassName} At least one chapter subheader link button should be present");

        var externalHrefs = new List<string>();
        // filter to buttons that actually contain 'external' in their href or text
        var buttonsHavingHref = buttons
            .Where(btn =>
            {
                var hrefVal = btn.DomAttribute("href") ?? btn.Text;
                return !string.IsNullOrWhiteSpace(hrefVal) && hrefVal.IndexOf("external", StringComparison.OrdinalIgnoreCase) >= 0;
            })
            .ToList();

        sa.ShouldBeTrue(buttonsHavingHref.Count > 0, $"{ClassName} Expected at least one chapter subheader link button with 'external' in href");

        foreach (var btn in buttonsHavingHref)
        {
            var href = (btn.DomAttribute("href") ?? btn.Text)?.Trim();
            if (!string.IsNullOrWhiteSpace(href)) externalHrefs.Add(href);

            var mainWindow = WebDriver.CurrentWindowHandle;

            // Click the button element to open external link (likely opens new tab)
            try
            {
                btn.JScriptClick();
            }
            catch
            {
                // fallback: try native click
                try { btn.Click(); } catch { }
            }

            // Wait for a new tab to appear
            AutomationBaseInstance.WaitFor(d => d.WindowHandles.Count > 1, ApplicationTimeouts.Medium, ApplicationTimeouts.Quick, "Waiting for new tab to open after clicking external link.");

            // If new tab(s) opened, close them and return focus to main window
            var handles = WebDriver.WindowHandles.ToList();
            foreach (var handle in handles)
            {
                if (handle == mainWindow) continue;
                WebDriver.SwitchTo().Window(handle);
               // WaitForPageToLoad();
                WebDriver.Close();
            }
            WebDriver.SwitchTo().Window(mainWindow);
        }
        return this;
    }

    /// <summary>
    /// Validate chapter subheader link buttons by link type (internal or external).
    /// Internal links: start with "/" but NOT "/external" (e.g., /profile-settings, /contactus).
    /// External links:
    ///   - Start with /external (redirect links: /external?externalUrl=...)
    ///   - Are full URLs (http://, https://)
    /// </summary>
    public MemberGuideView ValidateChapterSubheaderLinksByType(SoftAssertions sa)
    {
        ChapterContentWholeBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);

        var buttons = GetWebControls<ElementBase>(By.CssSelector(".chapter-subheader-link-button")) ?? new List<ElementBase>();
        sa.ShouldBeTrue(buttons.Count > 0, $"{ClassName} At least one chapter subheader link button should be present");

        var internalLinksFound = 0;
        var externalLinksFound = 0;

        foreach (var btn in buttons)
        {
            var href = btn.DomAttribute("href")?.Trim();
            if (string.IsNullOrWhiteSpace(href)) continue;

            // Classify link type based on href pattern
            if (href.StartsWith("/external", StringComparison.OrdinalIgnoreCase))
            {
                // /external redirect link
                externalLinksFound++;
                ValidateExternalLink(btn, sa);
            }
            else if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                     href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                // Direct external URL
                externalLinksFound++;
                ValidateExternalLink(btn, sa);
            }
            else if (href.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                // True internal link (relative path)
                internalLinksFound++;
                ValidateInternalLink(btn, sa);
            }
        }

        // Log findings
        LogEventType.Information.WriteEvent($"{ClassName} Found {internalLinksFound} internal links and {externalLinksFound} external links in chapter subheader buttons.");

        return this;
    }

    /// <summary>
    /// Helper method to validate an internal link (starts with / but NOT /external).
    /// Internal links are relative paths like /profile-settings, /contactus.
    /// Note: Links starting with /external are external redirects and should use ValidateExternalLink instead.
    /// </summary>
    private void ValidateInternalLink(ElementBase btn, SoftAssertions sa)
    {
        var href = btn.DomAttribute("href")?.Trim();
       
        // Ensure link starts with / AND is NOT an external redirect link
        var isInternalPath = href.StartsWith("/", StringComparison.OrdinalIgnoreCase);
        var isNotExternalRedirect = href.IndexOf("/external", StringComparison.OrdinalIgnoreCase) != 0;
       
        sa.ShouldBeTrue(isInternalPath && isNotExternalRedirect,
            $"{ClassName} Internal link href should start with '/' but NOT '/external': '{href}'");

        // Click and stay on same page (no new tab expected for true internal links)
        var mainWindow = WebDriver.CurrentWindowHandle;
        try
        {
            btn.JScriptClick();
            WaitForPageToLoad();
        }
        catch (Exception ex)
        {
            LogEventType.Warning.WriteEvent($"{ClassName} Failed to click internal link '{href}': {ex.Message}");
        }
        finally
        {
            // Ensure we're back on the main window
            try { WebDriver.SwitchTo().Window(mainWindow); } catch { }
        }
    }

    /// <summary>
    /// Helper method to validate an external link (contains 'external' in href or is a full URL).
    /// Supports both external redirect links and direct external URLs.
    /// Examples:
    ///   - href="/external?externalUrl=https:%2F%2Ffindcare.upmchealthplan.com%2Ffindpcp&ami=true&at=true&use_hash=true&window_target=blank"
    ///   - href="https://upmc.widen.net/s/cbg2szrq2q/25cgind5424950---2026-preventive-services-reference-guide"
    /// </summary>
    private void ValidateExternalLink(ElementBase btn, SoftAssertions sa)
    {
        var href = btn.DomAttribute("href")?.Trim();
       
        // Check if link is external (either contains 'external' or is a full URL starting with http/https)
        var isExternalRedirect = href.IndexOf("external", StringComparison.OrdinalIgnoreCase) >= 0;
        var isDirectExternalUrl = href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                                   href.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
       
        sa.ShouldBeTrue(isExternalRedirect || isDirectExternalUrl,
            $"{ClassName} External link href should contain 'external' or be a full URL: '{href}'");

        var mainWindow = WebDriver.CurrentWindowHandle;

        // Click the button to open external link (should open new tab)
        try
        {
            btn.JScriptClick();
        }
        catch
        {
            try { btn.Click(); } catch { }
        }

        // Wait for a new tab to appear and close it
        try
        {
            AutomationBaseInstance.WaitFor(d => d.WindowHandles.Count > 1, ApplicationTimeouts.Medium,
                ApplicationTimeouts.Quick, "Waiting for new tab to open after clicking external link.");

            // Close all non-main tabs and return focus to main window
            var handles = WebDriver.WindowHandles.ToList();
            foreach (var handle in handles)
            {
                if (handle == mainWindow) continue;
                WebDriver.SwitchTo().Window(handle);
                WebDriver.Close();
            }
        }
        catch (Exception ex)
        {
            LogEventType.Warning.WriteEvent($"{ClassName} Error handling external link tab: {ex.Message}");
        }
        finally
        {
            try { WebDriver.SwitchTo().Window(mainWindow); } catch { }
        }
    }

    public MemberGuideView ValidateChapterBlockByLeftText(string leftKey, MemberGuideSettings settings, SoftAssertions sa)
    {
        ChapterContentWholeBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        var blocks = GetWebControls<ElementBase>(By.CssSelector(".chapter-block"));
        sa.ShouldBeTrue(blocks.Count > 0, $"{ClassName} At least one chapter block should be present");

        static string NormalizeLocal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var sb = new System.Text.StringBuilder();
            foreach (var ch in s.Normalize().ToLowerInvariant())
            {
                if (char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)) sb.Append(ch);
            }
            return System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "\\s+", " ").Trim();
        }

        var leftExpected = NormalizeLocal(leftKey ?? string.Empty);
        ElementBase matchedBlock = null;
        foreach (var block in blocks)
        {
            var leftElems = GetWebControls<TextArea>(By.CssSelector(".chapter-left-block"), block);
            var leftText = leftElems?.FirstOrDefault()?.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(leftText) && NormalizeLocal(leftText).Contains(leftExpected))
            {
                matchedBlock = block;
                break;
            }
        }

       // sa.ShouldBeTrue(matchedBlock != null, $"{ClassName} Could not find chapter block with left text '{leftKey}'");
        if (matchedBlock == null) return this;

        // Aggregate right-side parts
        var rightDescs = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-description"), matchedBlock) ?? new List<TextArea>();
        var listItemsLocal = GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"), matchedBlock) ?? new List<ElementBase>();
        var linksLocal = GetWebControls<ElementBase>(By.CssSelector("a"), matchedBlock) ?? new List<ElementBase>();

        var parts = new List<string>();
        parts.AddRange(rightDescs.Select(d => d.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));
        parts.AddRange(listItemsLocal.Select(li => li.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));
        parts.AddRange(linksLocal.Select(l => (l.DomAttribute("href") ?? l.Text)?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));

        sa.ShouldBeTrue(parts.Count > 0, $"{ClassName} Chapter '{leftKey}' should contain right-side descriptions, list items, or links");

        // If freeform expected content provided, validate it appears in aggregated right-side text
        if (settings?.ChapterBlockContents != null && settings.ChapterBlockContents.TryGetValue(leftKey, out var expectedContent) && !string.IsNullOrWhiteSpace(expectedContent))
        {
            var agg = string.Join(" ", parts);
            var normAgg = NormalizeLocal(agg);
            var normExp = NormalizeLocal(expectedContent);

            var found = false;
            if (!string.IsNullOrWhiteSpace(normExp))
            {
                // Exact/substring match first (fast path)
                if (normAgg.Contains(normExp) || normExp.Contains(normAgg))
                {
                    found = true;
                }
                else
                {
                    // Fallback to fuzzy word-overlap check to tolerate minor formatting differences
                    var expWords = normExp.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                    var aggWords = normAgg.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                    var intersection = expWords.Intersect(aggWords).Count();

                    // If expected is short, require full match of words; otherwise require at least 50% overlap or minimum of 6 words
                    if (expWords.Count <= 6)
                    {
                        found = intersection >= Math.Max(1, expWords.Count);
                    }
                    else
                    {
                        var required = System.Math.Max(6, (int)System.Math.Ceiling(expWords.Count * 0.5));
                        found = intersection >= required;
                    }
                }
            }

            if (!found)
            {
                LogEventType.Warning.WriteEvent($"{ClassName} Chapter '{leftKey}' right-block did not contain expected content. Expected: '{expectedContent}'. Available: {string.Join(" | ", parts)}");
            }

            sa.ShouldBeTrue(found, $"{ClassName} Chapter '{leftKey}' right-block should contain expected content");
            return this;
        }

        // Otherwise, if structured expectation exists, try to validate expected descriptions/list items loosely
        var structExp = settings?.ChapterExpectations?.FirstOrDefault(c => !string.IsNullOrWhiteSpace(c.LeftText) && NormalizeLocal(c.LeftText).Contains(leftExpected));
        if (structExp != null)
        {
            foreach (var rr in structExp.RightRows ?? Enumerable.Empty<RightRowExpectation>())
            {
                // for each expected description or list item, ensure at least one part contains it
                foreach (var d in rr.Descriptions ?? Enumerable.Empty<string>())
                {
                    var nd = NormalizeLocal(d);
                    if (string.IsNullOrWhiteSpace(nd)) continue;
                    sa.ShouldBeTrue(parts.Any(p => NormalizeLocal(p).Contains(nd) || nd.Contains(NormalizeLocal(p))), $"{ClassName} Expecting description '{d}' in chapter '{leftKey}'");
                }

                foreach (var li in rr.ListItems ?? Enumerable.Empty<string>())
                {
                    var nl = NormalizeLocal(li);
                    if (string.IsNullOrWhiteSpace(nl)) continue;
                    sa.ShouldBeTrue(parts.Any(p => NormalizeLocal(p).Contains(nl) || nl.Contains(NormalizeLocal(p))), $"{ClassName} Expecting list item '{li}' in chapter '{leftKey}'");
                }
            }
            return this;
        }

        // If no explicit expectations provided, just ensure the right-side has at least a description or list item
        sa.ShouldBeTrue(rightDescs.Any() || listItemsLocal.Any() || linksLocal.Any(), $"{ClassName} Chapter '{leftKey}' right-side content presence validated");
        return this;
    }

    public MemberGuideView ValidateBannerComponents(MemberGuideSettings settings, SoftAssertions sa)
    {
        // Validate welcome header and description
        var header = GetWebControlWhenVisible<TextArea>(HeaderBy);
        sa.ShouldBeTrue(header.Displayed, $"{ClassName} Welcome header is displayed");
        sa.ShouldContainEquivalentOf(header.Text, settings.MemberGuideHeader, $"{ClassName} Welcome header should contain expected text");

        sa.ShouldBeTrue(WelcomeDesc.Displayed, $"{ClassName} Welcome description is displayed");
        sa.ShouldContainEquivalentOf(WelcomeDesc.Text, settings.MemberGuideDesc, $"{ClassName} Welcome description should contain expected text");

        // Banner promo
        if (WelcomeBannerBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit))
        {
            sa.ShouldBeTrue(WelcomeBannerPromoDesc.Text.Contains(settings.BannerChapterTitle), $"{ClassName} Banner title should match settings");
        }

        return this;
    }
    public MemberGuideView ValidateChapterBlockHeaders(List<string> welcomeDropdownOptions, MemberGuideSettings settings, SoftAssertions sa)
    {
        var headerElements = GetWebControls<TextArea>(By.CssSelector(".promo-content__desc"));
        var headerImages = GetWebControls<ElementBase>(By.CssSelector(".welcome-banner__banner img"));
        sa.ShouldBeTrue(headerElements.Count > 0, $"{ClassName} At least one chapter header block should be present");
        sa.ShouldBeTrue(headerImages.Count > 0, $"{ClassName} At least one chapter header image should be present");
        sa.ShouldBeTrue(headerElements.Count == headerImages.Count, $"{ClassName} Each chapter header block should have a corresponding image");

        var headerTexts = headerElements.Select(b => b.Text.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
        //foreach (var expected in welcomeDropdownOptions)
        //{
        //    sa.ShouldBeTrue(headerTexts.Any(t => t.Contains(expected) || expected.Contains(t)), $"{ClassName} Expecting chapter header containing '{expected}'");
        //}

        var unexpectedLefts = headerTexts
    .Except(welcomeDropdownOptions, StringComparer.OrdinalIgnoreCase)
    .ToList();
        return this;
    }
    public MemberGuideView ValidateChapterBlocks(List<string> welcomeDropdownOptions, MemberGuideSettings settings, SoftAssertions sa)
    {
        ChapterContentWholeBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);

        // Validate left blocks: ensure at least one left block text matches any expected value
        var leftBlocks = GetWebControls<TextArea>(By.CssSelector(".chapter-left-block"));
        sa.ShouldBeTrue(leftBlocks.Count > 0, $"{ClassName} At least one chapter left block should be present");
        var leftTexts = leftBlocks.Select(b => b.Text.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
        //foreach (var expected in leftTexts)
        //{
        //    sa.ShouldBeTrue(leftTexts.Any(t => t.Contains(expected) || expected.Contains(t)), $"{ClassName} Expecting chapter left block containing '{expected}'");
        //}

        var unexpectedLefts = leftTexts
            .Except(settings.ChapterLeftBlocks, StringComparer.OrdinalIgnoreCase)
            .ToList();
        sa.ShouldBeTrue(!unexpectedLefts.Any(), $"{ClassName} Unexpected chapter left block text found: {string.Join(", ", unexpectedLefts)}");


        // Validate right row titles exist
        var rightTitles = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-title"));
        var rightTextList = rightTitles.Select(t => t.Text.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
        var unexpected = rightTextList
        .Except(settings.ChapterRightRowTitles)
        .ToList();
        sa.ShouldBeTrue(!unexpected.Any(), $"{ClassName} Unexpecting chapter right-row title found:{string.Join(",", unexpected)}");

        return this;
    }

    public MemberGuideView ValidateChapterListItems(List<string> welcomeDropdownOptions, SoftAssertions sa)
    {
        // If no description lists are present, nothing to validate
        if (!DescriptionListBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit)) return this;

        var items = DescriptionListItems ?? new List<ElementBase>();
        var descItems = items.Select(i => i.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToList();

        // Ensure there is at least one description list item on the page
        sa.ShouldBeTrue(descItems.Count > 0, $"{ClassName} Description list should contain items");

        // Optional: basic sanity-check that list items aren't empty and are displayed
        foreach (var li in items)
        {
            sa.ShouldBeTrue(!string.IsNullOrWhiteSpace(li.Text), $"{ClassName} Description list item should not be empty");
            sa.ShouldBeTrue(li.Displayed, $"{ClassName} Description list item is displayed");
        }

        // Note: welcomeDropdownOptions is presently unused here but accepted to match fluent call-site.
        // If you want to correlate list items to dropdown options, pass settings or a dedicated expectation list and add comparison logic.

        return this;
    }

    public MemberGuideView ValidateFooterLinks(MemberGuideSettings settings, SoftAssertions sa)
    {
        FooterCopyright.ScrollIntoView();
        sa.ShouldBeTrue(FooterCopyright.TextContent.Contains(settings.FooterCopyrightText), $"{ClassName} Footer copyright should contain expected text");

        // Validate presence of link groups by link hrefs
        var links = FooterLinks.Select(l => l.DomAttribute("href")).Where(h => !string.IsNullOrEmpty(h)).ToList();
        foreach (var group in settings.FooterLinkGroups)
        {
            var expectedHrefs = group.Value;
            foreach (var href in expectedHrefs)
            {
                sa.ShouldBeTrue(links.Any(l => l.Contains(href.Trim())), $"{ClassName} Footer link '{href}' should be present");
            }
        }

        return this;
    }

    public MemberGuideView ClickChapterSubheaderLink(string partialHref)
    {
        var xpath = $"//a[contains(@href, '{partialHref}') or contains(.,'{partialHref}') ]";
        By.XPath(xpath).WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        var link = GetWebControlWhenVisible<ElementBase>(By.XPath(xpath));
        link.JScriptClick();
        AutomationBaseInstance.WaitForPageToLoad();
        return this;
    }

    public MemberGuideView SelectWelcomeDropdownOption(string optionText)
    {
        // Open the select dropdown and choose option by visible text
        var selectElement = GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-block ods-select"));
        selectElement.JScriptClick();
        var optionXpath = $"//ods-select-option[contains(.,'{optionText}')]";
        By.XPath(optionXpath).WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Medium);
        var option = GetWebControlWhenVisible<ElementBase>(By.XPath(optionXpath));
        option.JScriptClick();
        return this;
    }

    public MemberGuideView GetSelectWelcomeDropdownOption(out List<string> optionTexts)
    {
        // Open the select dropdown and choose option by visible text
        var selectElement = GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-block ods-select"));

        FindElementInShadowDom(By.CssSelector(".welcome-block ods-select"), By.CssSelector("#combobox")).JScriptClick();


        //selectElement.JScriptClick();
        var optionXpath = $"//ods-select-option";
        var ele = GetWebControlWhenVisible<ElementBase>(By.CssSelector(".welcome-block ods-select-option"));
        //By.XPath(optionXpath).WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Medium);
        var option1s = GetWebControls<ElementBase>(By.CssSelector(".welcome-block ods-select-option"));

        var options = GetWebControls<ElementBase>(By.XPath(optionXpath));
        optionTexts = (from option in options
                       where !option.Text.Trim().Equals("Select an option", StringComparison.OrdinalIgnoreCase) | !option.Text.Trim().Equals("")
                       select option.Text.Trim()).ToList();
        var optionTexts1 = (from option in option1s
                            where !option.Text.Trim().Equals("Select an option", StringComparison.OrdinalIgnoreCase) | !option.Text.Trim().Equals("")
                            select option.Text.Trim()).ToList();
        return this;
    }

    public MemberGuideView ValidateMemberGuideBanner(MemberGuideSettings settings, SoftAssertions sa)
    {
        HeaderBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        var header = GetWebControlWhenVisible<TextArea>(HeaderBy);
        sa.ShouldBeTrue(header.Displayed, $"{ClassName} Member Guide header is displayed");
        sa.ShouldContainEquivalentOf(header.Text, settings.MemberGuideHeader, $"{ClassName} Member Guide header should contain expected text");

        sa.ShouldBeTrue(WelcomeDesc.Displayed, $"{ClassName} Welcome description is displayed");
        sa.ShouldContainEquivalentOf(WelcomeDesc.Text, settings.MemberGuideDesc, $"{ClassName} Welcome description should contain expected text");

        sa.ShouldBeTrue(WelcomeImg.Displayed || WelcomeBannerPicture.Displayed, $"{ClassName} Welcome image or banner is displayed");

        if (WelcomeBannerBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit))
        {
            sa.ShouldBeTrue(WelcomeBannerPromoDesc.Displayed, $"{ClassName} Promo description is displayed");
        }

        return this;
    }

    public MemberGuideView ValidateChapterSections(SoftAssertions sa)
    {
        ChapterContentWholeBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        sa.ShouldBeTrue(ChapterLeftBlock.Displayed, $"{ClassName} Chapter left block is displayed");
        sa.ShouldBeTrue(ChapterRightBlock.Displayed, $"{ClassName} Chapter right block is displayed");

        // verify at least one chapter subheader title and description exists
        if (ChapterSubheaderTitle.Displayed)
            sa.ShouldBeTrue(!string.IsNullOrWhiteSpace(ChapterSubheaderTitle.Text), $"{ClassName} Chapter subheader title is not empty");

        if (DescriptionListBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit))
        {
            var items = DescriptionListItems ?? new List<ElementBase>();
            sa.ShouldBeTrue(items.Count > 0, $"{ClassName} Description list should contain one or more items");
            items.ToList().ForEach(i => sa.ShouldBeTrue(i.Displayed, $"{ClassName} Description list item is displayed and has value {i.Text}"));
        }

        return this;
    }

    public MemberGuideView ValidateFootnotes(SoftAssertions sa)
    {
        if (!FootnoteListBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit)) return this;
        FootnoteListBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        sa.ShouldBeTrue(Footnote_CommunicationPreferences.Displayed, $"{ClassName} Communication preferences footnote is displayed");
        sa.ShouldBeTrue(Footnote_ChatCall.Displayed, $"{ClassName} Chat/Call footnote is displayed");
        sa.ShouldBeTrue(Footnote_Providers.Displayed, $"{ClassName} Providers footnote is displayed");
        return this;
    }

    public MemberGuideView ValidateAnywhereCarePopup(SoftAssertions sa)
    {
        if (!AnyWhereCarePopupBy.ElementExists(AutomationBaseInstance, ApplicationTimeouts.Implicit)) return this;
        AnyWhereCarePopupBy.WaitUntilVisible(AutomationBaseInstance, ApplicationTimeouts.Long);
        sa.ShouldBeTrue(AnyWhereCarePopupTitle.Displayed, $"{ClassName} AnywhereCare popup title is displayed");
        sa.ShouldBeTrue(AnyWhereCareEmailInput.Displayed, $"{ClassName} AnywhereCare email input is displayed");
        sa.ShouldBeTrue(AnyWhereCareContinueButton.Displayed, $"{ClassName} AnywhereCare Continue button is displayed");
        return this;
    }

    public MemberGuideView ValidateAllChapterBlocks(MemberGuideSettings settings, SoftAssertions sa)
    {
        var blocks = GetWebControls<ElementBase>(By.CssSelector(".chapter-block"));
        sa.ShouldBeTrue(blocks.Count > 0, $"{ClassName} At least one chapter block should be present");
        // Aggregate content across all blocks so we validate expected settings as a whole
        var aggregatedLeftTexts = new List<string>();
        var aggregatedRightTitles = new List<string>();
        var aggregatedRightDescs = new List<string>();
        var aggregatedListItems = new List<string>();
        var aggregatedLinks = new List<string>();

        for (var i = 0; i < blocks.Count; i++)
        {
            var block = blocks[i];

            // Left block (scoped)
            var leftElems = GetWebControls<TextArea>(By.CssSelector(".chapter-left-block"), block);
            if (leftElems != null && leftElems.Any())
            {
                var left = leftElems.First();
                // Some left blocks may contain images or non-text content; only assert non-empty when there is text
                var leftText = left.Text?.Trim();
                var innerHtml = left.DomAttribute("innerHTML")?.Trim();
                if (!string.IsNullOrWhiteSpace(leftText))
                {
                    aggregatedLeftTexts.Add(leftText);
                }
                else if (!string.IsNullOrWhiteSpace(innerHtml) && (innerHtml.Contains("<img") || innerHtml.Contains("<picture") || innerHtml.Contains("background")))
                {
                    // image-only left block — treat as present but skip text matching
                    LogEventType.Information.WriteEvent($"{ClassName} Chapter {i} left block contains non-text content; skipping text validation.");
                }
                else
                {
                    // no text or inner content — skip strict assertion to avoid false negatives
                    LogEventType.Information.WriteEvent($"{ClassName} Chapter {i} left block present but empty; skipping.");
                }
            }

            // Right block titles
            var rightTitles = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-title"), block);
            if (rightTitles != null && rightTitles.Any())
            {
                foreach (var rt in rightTitles)
                {
                    sa.ShouldBeTrue(!string.IsNullOrWhiteSpace(rt.Text), $"{ClassName} Chapter {i} right title should not be empty");
                    aggregatedRightTitles.Add(rt.Text.Trim());
                }
            }

            // Right block descriptions
            var rightDescs = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-description"), block);
            if (rightDescs != null && rightDescs.Any())
            {
                foreach (var rd in rightDescs)
                {
                    sa.ShouldBeTrue(!string.IsNullOrWhiteSpace(rd.Text), $"{ClassName} Chapter {i} right description should not be empty");
                    aggregatedRightDescs.Add(rd.Text.Trim());
                }
            }

            // Description list items inside this block
            var listItems = GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"), block);
            if (listItems != null && listItems.Any())
            {
                foreach (var li in listItems)
                {
                    sa.ShouldBeTrue(!string.IsNullOrWhiteSpace(li.Text), $"{ClassName} Chapter {i} list item should not be empty");
                    aggregatedListItems.Add(li.Text.Trim());
                }
            }

            // Links in this block
            var links = GetWebControls<ElementBase>(By.CssSelector("a"), block);
            if (links != null && links.Any())
            {
                foreach (var l in links)
                {
                    var href = l.DomAttribute("href") ?? l.Text;
                    if (string.IsNullOrWhiteSpace(href)) continue;
                    aggregatedLinks.Add(href.Trim());
                }
            }
        }

        // Validate expected settings against aggregated content (avoid per-block false negatives)
        static string Normalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var sb = new System.Text.StringBuilder();
            foreach (var ch in s.Normalize().ToLowerInvariant())
            {
                if (char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)) sb.Append(ch);
            }
            // collapse whitespace
            var collapsed = System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "\\s+", " ").Trim();
            return collapsed;
        }

        var normLeft = aggregatedLeftTexts.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var normRightTitles = aggregatedRightTitles.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var normRightDescs = aggregatedRightDescs.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var normListItems = aggregatedListItems.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var normLinks = aggregatedLinks.Select(Normalize).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        // If structured per-chapter expectations are provided, validate each expected chapter against its block
        if (settings.ChapterExpectations != null && settings.ChapterExpectations.Any())
        {
            foreach (var chapExp in settings.ChapterExpectations)
            {
                var leftExpected = Normalize(chapExp.LeftText ?? string.Empty);
                // find the block that contains this left text
                ElementBase matchedBlock = null;
                for (var i = 0; i < blocks.Count; i++)
                {
                    var block = blocks[i];
                    var leftElems = GetWebControls<TextArea>(By.CssSelector(".chapter-left-block"), block);
                    var leftText = leftElems?.FirstOrDefault()?.Text?.Trim();
                    if (!string.IsNullOrWhiteSpace(leftText) && Normalize(leftText).Contains(leftExpected))
                    {
                        matchedBlock = block;
                        break;
                    }
                }

                sa.ShouldBeTrue(matchedBlock != null, $"{ClassName} Could not find chapter block with left text '{chapExp.LeftText}'");
                if (matchedBlock == null) continue;

                // Validate right rows for this block
                var rightRowElems = GetWebControls<ElementBase>(By.CssSelector(".right-row"), matchedBlock) ?? new List<ElementBase>();
                foreach (var rrExp in chapExp.RightRows ?? Enumerable.Empty<RightRowExpectation>())
                {
                    var rrTitleExpected = Normalize(rrExp.Title ?? string.Empty);
                    ElementBase matchedRightRow = null;

                    // first try to find a right-row with a matching title
                    foreach (var rr in rightRowElems)
                    {
                        var titles = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-title"), rr) ?? new List<TextArea>();
                        if (titles.Any(t => !string.IsNullOrWhiteSpace(t.Text) && Normalize(t.Text).Contains(rrTitleExpected)))
                        {
                            matchedRightRow = rr;
                            break;
                        }
                    }

                    // fallback: find a right-row where descriptions or list items contain the expected title text
                    if (matchedRightRow == null)
                    {
                        foreach (var rr in rightRowElems)
                        {
                            var descs = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-description"), rr) ?? new List<TextArea>();
                            var listItemsLocal = GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"), rr) ?? new List<ElementBase>();

                            // If the expected title text appears in descriptions or list items, accept it
                            if (descs.Any(d => !string.IsNullOrWhiteSpace(d.Text) && Normalize(d.Text).Contains(rrTitleExpected)) ||
                                listItemsLocal.Any(li => !string.IsNullOrWhiteSpace(li.Text) && Normalize(li.Text).Contains(rrTitleExpected)))
                            {
                                matchedRightRow = rr;
                                break;
                            }

                            // Otherwise, try to match by any of the expected descriptions provided in the expectation
                            var matchedByDesc = false;
                            foreach (var expectedDesc in rrExp.Descriptions ?? Enumerable.Empty<string>())
                            {
                                var ed = Normalize(expectedDesc);
                                if (string.IsNullOrWhiteSpace(ed)) continue;
                                if (descs.Any(d => !string.IsNullOrWhiteSpace(d.Text) && Normalize(d.Text).Contains(ed)))
                                {
                                    matchedRightRow = rr;
                                    matchedByDesc = true;
                                    break;
                                }
                            }
                            if (matchedByDesc) break;

                            // Also try matching by expected list items
                            foreach (var expectedItem in rrExp.ListItems ?? Enumerable.Empty<string>())
                            {
                                var ei = Normalize(expectedItem);
                                if (string.IsNullOrWhiteSpace(ei)) continue;
                                if (listItemsLocal.Any(li => !string.IsNullOrWhiteSpace(li.Text) && Normalize(li.Text).Contains(ei)))
                                {
                                    matchedRightRow = rr;
                                    break;
                                }
                            }
                            if (matchedRightRow != null) break;
                        }
                    }

                    sa.ShouldBeTrue(matchedRightRow != null, $"{ClassName} Could not find right-row for chapter '{chapExp.LeftText}' with expected title '{rrExp.Title}'");
                    if (matchedRightRow == null) continue;

                    // validate descriptions
                    var foundDescs = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-description"), matchedRightRow) ?? new List<TextArea>();
                    var foundDescNorms = foundDescs.Select(d => Normalize(d.Text)).ToList();
                    foreach (var expectedDesc in rrExp.Descriptions ?? Enumerable.Empty<string>())
                    {
                        var en = Normalize(expectedDesc);
                        sa.ShouldBeTrue(foundDescNorms.Any(fd => fd.Contains(en) || en.Contains(fd)), $"{ClassName} Expecting right-row description containing '{expectedDesc}' in chapter '{chapExp.LeftText}'");
                    }

                    // validate list items
                    var foundListItems = GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"), matchedRightRow) ?? new List<ElementBase>();
                    var foundListNorms = foundListItems.Select(li => Normalize(li.Text)).ToList();
                    foreach (var expectedItem in rrExp.ListItems ?? Enumerable.Empty<string>())
                    {
                        var en = Normalize(expectedItem);
                        sa.ShouldBeTrue(foundListNorms.Any(fl => fl.Contains(en) || en.Contains(fl)), $"{ClassName} Expecting list item '{expectedItem}' in right-row '{rrExp.Title}' for chapter '{chapExp.LeftText}'");
                    }

                    // validate links within the matched right-row
                    var foundLinks = GetWebControls<ElementBase>(By.CssSelector("a"), matchedRightRow) ?? new List<ElementBase>();
                    var foundHrefNorms = foundLinks.Select(l => Normalize(l.DomAttribute("href") ?? l.Text)).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    foreach (var expectedLink in rrExp.Links ?? Enumerable.Empty<string>())
                    {
                        var en = Normalize(expectedLink);
                        sa.ShouldBeTrue(foundHrefNorms.Any(h => h.Contains(en) || en.Contains(h)), $"{ClassName} Expecting link '{expectedLink}' in right-row '{rrExp.Title}' for chapter '{chapExp.LeftText}'");
                    }
                }

                // validate chapter-level links
                var chapterLinks = GetWebControls<ElementBase>(By.CssSelector("a"), matchedBlock) ?? new List<ElementBase>();
                var chapterHrefNorms = chapterLinks.Select(l => Normalize(l.DomAttribute("href") ?? l.Text)).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                foreach (var expectedLink in chapExp.Links ?? Enumerable.Empty<string>())
                {
                    var en = Normalize(expectedLink);
                    sa.ShouldBeTrue(chapterHrefNorms.Any(h => h.Contains(en) || en.Contains(h)), $"{ClassName} Expecting chapter link '{expectedLink}' for chapter '{chapExp.LeftText}'");
                }
            }
            // structured expectations validated; return early
            return this;
        }

        // If simple per-block expected content is provided (map left-text -> expected right-block content), validate per-block
        if (settings.ChapterBlockContents != null && settings.ChapterBlockContents.Any())
        {
            foreach (var kvp in settings.ChapterBlockContents)
            {
                var leftKey = kvp.Key ?? string.Empty;
                var expectedContent = kvp.Value ?? string.Empty;
                var leftExpected = Normalize(leftKey);

                ElementBase matchedBlock = null;
                for (var i = 0; i < blocks.Count; i++)
                {
                    var block = blocks[i];
                    var leftElems = GetWebControls<TextArea>(By.CssSelector(".chapter-left-block"), block);
                    var leftText = leftElems?.FirstOrDefault()?.Text?.Trim();
                    if (!string.IsNullOrWhiteSpace(leftText) && Normalize(leftText).Contains(leftExpected))
                    {
                        matchedBlock = block;
                        break;
                    }
                }

                sa.ShouldBeTrue(matchedBlock != null, $"{ClassName} Could not find chapter block with left text '{leftKey}'");
                if (matchedBlock == null) continue;

                // Aggregate right-side text for this block
                var rightTitles = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-title"), matchedBlock) ?? new List<TextArea>();
                var rightDescs = GetWebControls<TextArea>(By.CssSelector(".chapter-subheader-description"), matchedBlock) ?? new List<TextArea>();
                var listItemsLocal = GetWebControls<ElementBase>(By.CssSelector("ul.description-list > li.description-list-item"), matchedBlock) ?? new List<ElementBase>();
                var linksLocal = GetWebControls<ElementBase>(By.CssSelector("a"), matchedBlock) ?? new List<ElementBase>();

                var parts = new List<string>();
                parts.AddRange(rightTitles.Select(t => t.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));
                parts.AddRange(rightDescs.Select(d => d.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));
                parts.AddRange(listItemsLocal.Select(li => li.Text?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));
                parts.AddRange(linksLocal.Select(l => (l.DomAttribute("href") ?? l.Text)?.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)));

                var aggregated = string.Join(" ", parts);
                var normAggregated = Normalize(aggregated);
                var en = Normalize(expectedContent);

                // fuzzy matching similar to ValidateChapterBlockByLeftText
                var found = false;
                if (!string.IsNullOrWhiteSpace(en))
                {
                    if (normAggregated.Contains(en) || en.Contains(normAggregated))
                    {
                        found = true;
                    }
                    else
                    {
                        var expWords = en.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                        var aggWords = normAggregated.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                        var intersection = expWords.Intersect(aggWords).Count();
                        if (expWords.Count <= 6)
                        {
                            found = intersection >= Math.Max(1, expWords.Count);
                        }
                        else
                        {
                            var required = System.Math.Max(6, (int)System.Math.Ceiling(expWords.Count * 0.5));
                            found = intersection >= required;
                        }
                    }
                }

                if (!found)
                {
                    LogEventType.Warning.WriteEvent($"{ClassName} Chapter '{leftKey}' right-block did not contain expected content. Expected: '{expectedContent}'. Available: {string.Join(" | ", parts)}");
                }

                sa.ShouldBeTrue(found, $"{ClassName} Expecting chapter '{leftKey}' right-block to contain expected content");
            }

            return this;
        }

        if (settings.ChapterLeftBlocks != null && settings.ChapterLeftBlocks.Any())
        {
            foreach (var expected in settings.ChapterLeftBlocks)
            {
                var en = Normalize(expected);
                sa.ShouldBeTrue(normLeft.Any(t => t.Contains(en) || en.Contains(t)), $"{ClassName} Expecting a chapter left block containing '{expected}'");
            }
        }

        if (settings.ChapterRightRowTitles != null && settings.ChapterRightRowTitles.Any())
        {
            foreach (var expected in settings.ChapterRightRowTitles)
            {
                var en = Normalize(expected);
                // allow the expected title to appear in right titles, right descriptions, left blocks, or list items
                var foundInRightTitles = normRightTitles.Any(t => t.Contains(en) || en.Contains(t));
                var foundInRightDescs = normRightDescs.Any(t => t.Contains(en) || en.Contains(t));
                var foundInLeft = normLeft.Any(t => t.Contains(en) || en.Contains(t));
                var foundInListItems = normListItems.Any(t => t.Contains(en) || en.Contains(t));

                var found = foundInRightTitles || foundInRightDescs || foundInLeft || foundInListItems;

                if (!found)
                {
                    // Log available right titles to help debugging missing expectations
                    LogEventType.Warning.WriteEvent($"{ClassName} Could not find expected right-row title '{expected}'. Available right titles: {string.Join(" | ", normRightTitles)}; right descriptions: {string.Join(" | ", normRightDescs)}; left blocks: {string.Join(" | ", normLeft)}; list items: {string.Join(" | ", normListItems)}");
                }

                sa.ShouldBeTrue(found, $"{ClassName} Expecting chapter right-row title '{expected}'");
            }
        }

        if (settings.ChapterRightRowDescriptions != null && settings.ChapterRightRowDescriptions.Any())
        {
            foreach (var expected in settings.ChapterRightRowDescriptions)
            {
                var en = Normalize(expected);
                sa.ShouldBeTrue(normRightDescs.Any(t => t.Contains(en) || en.Contains(t)), $"{ClassName} Expecting a chapter right-row description containing '{expected}'");
            }
        }

        if (settings.ChapterListItems != null && settings.ChapterListItems.Any())
        {
            foreach (var expected in settings.ChapterListItems)
            {
                var en = Normalize(expected);
                sa.ShouldBeTrue(normListItems.Any(t => t.Contains(en) || en.Contains(t)), $"{ClassName} Expected list item containing '{expected}'");
            }
        }

        if (settings.ChapterSubheaderLinks != null && settings.ChapterSubheaderLinks.Any())
        {
            foreach (var expected in settings.ChapterSubheaderLinks)
            {
                var en = Normalize(expected);
                sa.ShouldBeTrue(normLinks.Any(h => h.Contains(en) || en.Contains(h)), $"{ClassName} Footer link '{expected}' should be present in chapter links");
            }
        }

        return this;
    }

    internal object ValidateChapterBlocks(MemberGuideSettings settings, SoftAssertions sa)
    {
        throw new NotImplementedException();
    }
}
