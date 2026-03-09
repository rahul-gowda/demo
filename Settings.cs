using MemberSiteAppTests.APITests.DataModels.PreferenceCenter;

namespace MemberSiteAppTests.Common
{
    public class MemberGuideSettings
    {
        public string MemberGuideHeader { get; set; }
        public string MemberGuideDesc { get; private set; }
        public string KnowYourNetworkType { get; private set; }
        public string WhatIsANetwork { get; private set; }
        public string WhatIsANetworkDesc { get; private set; }
        public string WhatIsAPlan { get; private set; }
        public string WhatIsAPlanDesc { get; private set; }

        // Additional content pulled from the DOM (flattened into same file per request)
        public string WelcomeHeader { get; private set; }
        public string WelcomeDescription { get; private set; }
        public string WelcomeImageUrl { get; private set; }
        public string BannerChapterLabel { get; private set; }
        public string BannerChapterTitle { get; private set; }
        public string BannerImageUrl { get; private set; }
        public List<string> ChapterLeftBlocks { get; private set; }
        public List<string> ChapterRightRowTitles { get; private set; }
        public List<string> ChapterRightRowDescriptions { get; private set; }
        public List<string> ChapterSubheaderLinks { get; private set; }
        public List<string> ChapterListItems { get; private set; }
        public List<string> ChapterDescriptionItems { get; private set; }
        // Structured expectations per chapter
        public List<ChapterExpectation> ChapterExpectations { get; private set; }
        // Map of left-block text -> expected aggregated right-block content (free-form)
        public Dictionary<string, string> ChapterBlockContents { get; private set; }
        public Dictionary<string, string> Footnotes { get; private set; }
        public string PopupTitle { get; private set; }
        public string PopupBody { get; private set; }
        public string PopupContinueButtonText { get; private set; }
        public string ChatbotStartButtonText { get; private set; }
        public List<string> ChatbotBotMessages { get; private set; }
        public string ChatInputPlaceholder { get; private set; }
        public string ChatSendButtonText { get; private set; }
        public string FooterCopyrightText { get; private set; }
        public Dictionary<string, string[]> FooterLinkGroups { get; private set; }

        // Structured expectation types used by MemberGuideSettings
        public class ChapterExpectation
        {
            public string LeftText { get; set; }
            public List<RightRowExpectation> RightRows { get; set; } = new List<RightRowExpectation>();
            public List<string> Links { get; set; } = new List<string>();
        }

        public class RightRowExpectation
        {
            public string Title { get; set; }
            public List<string> Descriptions { get; set; } = new List<string>();
            public List<string> ListItems { get; set; } = new List<string>();
            public List<string> Links { get; set; } = new List<string>();
        }
        public static MemberGuideSettings GetOnboardingTutorialSettings()
        {
            return new MemberGuideSettings
            {
                MemberGuideHeader = "Welcome to\r\nUPMC Health Plan",
                MemberGuideDesc = "We believe every person deserves a health plan that provides quality, choice, access, value, and service. Learn about what your plan offers by taking a few moments to read this guide.",
                KnowYourNetworkType = "Know your network and plan type",
                WhatIsANetwork = "What is a network?",
                WhatIsANetworkDesc = "A network is composed of doctors, hospitals, labs, imaging centers, and other providers who have contracted with UPMC Health Plan to care for you and our other members. By using providers who participate in your network, you can ensure that your care is covered and avoid unexpected costs.",
                WhatIsAPlan = "What is a plan?",
                WhatIsAPlanDesc = "A health plan is a contract between you and UPMC",
                // Additional DOM-derived defaults (flattened into same object)
                WelcomeHeader = "bernbern, Welcome to UPMC Health Plan",
                WelcomeDescription = "We believe every person deserves a health plan that provides quality, choice, access, value, and service. Learn about what your plan offers by taking a few moments to read this guide.",
                WelcomeImageUrl = "https://content.upmchp.com/mhol/digital-guide/2024/480%20x%20300.jpg",
                BannerChapterLabel = "Chapter",
                BannerChapterTitle = "Your member essentials",
                BannerImageUrl = "https://content.upmchp.com/mhol/digital-guide/2025/1_940%20x%20335-8.png",
                ChapterLeftBlocks = new List<string>
                {
                    "Your network and plan information\r\nYour network\r\nUPMC Premium\r\nYour plan\r\nPreferred provider organization (PPO)",
                    "Health insurance terms to know",
                    "Download the UPMC Health Plan app",
                    "Find a participating provider/select your primary care provider",
                    "Schedule a wellness visit",
                    "Go paperless",
                    "MyUPMC",
                    "Health Care Concierge",
                    "Your coverage",
                    "Cost of care",
                    "Explanation of Benefits",
                    "How to submit a claim",
                    "Your member ID card",
                    "LifeSolutions®",
                    "Programs and resources to support your health and well-being",
                    "Health and Wellness Discounts",
                    "Reproductive health services",
                    "Behavioral health services",
                    "Manage your health and health care expenses with the right resources.",
                    "Health care concierge",
                    "MyUPMC",
                    "Your coverage",
                    "Cost of care",
                    "Explanation of benefits",
                    "What is a network?",
                    "What is a plan?",
                    "Your network and plan information",
                    "Your network",
                    "UPMC Advantage",
                    "Your plan",
                    "Exclusive provider organization (EPO)",
                    "Your member ID card",
                    "Hearing health benefit (administered by Amplifon Hearing Health Care)",
                    "Getting your prescription",
                    "LifeSolutions®",
                    "Programs and resources to support your health and well-being",
                    "Health and wellness discounts",
                    "Reproductive health services",
                    "Behavioral health services",
                    "General",
                    "Other things to know",
                    "Your network and plan information\r\nYour network\r\nUPMC Advantage\r\nYour plan\r\nExclusive provider organization (EPO)",
                },
                // Structured expectations to validate left block and corresponding right-row content
                // Keep structured expectations minimal for now; single-block validation will use ChapterBlockContents
                ChapterExpectations = new List<ChapterExpectation> { },
                ChapterBlockContents = new Dictionary<string, string>
                {
                    { "Manage your health and health care expenses with the right resources.", "Manage your health and health care expenses with the right resources. Find a participating provider or select your primary care provider (PCP); download the UPMC Health Plan app for access to digital ID cards, claims, and virtual visits; schedule a wellness visit with your PCP; go paperless for secure online plan materials; and contact our Health Care Concierge team for help finding providers, checking coverage, or estimating costs." },
                    { "Download the UPMC Health Plan app", "Get on-the-go access to your health insurance information, benefits, and tools with the UPMC Health Plan app. For added convenience, you can use your UPMC Health Plan Login to access the app. With the app, you can: Access your plan details, medical claims, spending activity, and other digital tools. View and download digital ID cards for yourself and your covered family members. Find care, search for participating providers, select your primary care provider, and call a nurse with the UPMC MyHealth 24/7 Nurse Line." },
                    { "Find a participating provider/select your primary care provider", "It's important to choose a primary care provider (PCP) who participates with UPMC Health Plan. PCPs offer many no-cost services - including preventive screenings - that can help you get or stay healthy. They are also responsible for coordinating their patients' care with other healthcare providers. No-cost PCP services include: Personal care plan; $0 annual well-visits for adults and children; $0 preventive screenings; $0 flu shot; Coordinate your care when you are seeing multiple providers; Referrals to $0 health coaching for lifestyle changes or chronic condition management; Referrals to other participating providers or specialists. Searching for health care providers is easy with our online Find Care tool (filters include virtual primary care practices, offers virtual visits, accepting new patients). Select a PCP using the Find Care tool or the member app. " },
                    { "Schedule a wellness visit", "Having a wellness visit with your primary care provider (PCP) is essential for staying on top of your health." },
                    { "Go paperless", "When you choose to get your plan materials online, you have safe and easy access to your documents 24/7." },
                    { "MyUPMC", "Use MyUPMC.com and the MyUPMC app to review information about the care you've received from UPMC providers." },
                    { "Health Care Concierge", "Live chat or call our award-winning Health Care Concierge team to get help finding a provider, verify coverage, and more." },
                    { "Your coverage", "Before you seek care from providers, we recommend that you review your plan documents." },
                    { "Cost of care", "Cost sharing is where you and UPMC Health Plan will share the cost of your care. You have to pay your deductible before UPMC Health Plan will start covering your care costs." },
                    { "Explanation of Benefits", "Here's how the claims process works after you receive care: The provider will send UPMC Health Plan a claim. We will process the claim based on your plan. We will send you a notification to review your Explanation of Benefits (EOB) online or mail you a paper copy." },
                    { "How to submit a claim", "If you receive care from a participating provider, you will not have to submit a claim to UPMC Health Plan. However, if you obtain medically necessary covered services from a nonparticipating provider, you may have to file a claim yourself." },
                    { "Your member ID card", "Your member ID card is the key to your care and provides important information about your plan and your coverage." },
                    { "LifeSolutions®", "LifeSolutions offers counseling sessions and resources, including no-cost confidential coaching and counseling sessions for members." },
                    { "Programs and resources to support your health and well-being", "Health Coaching and condition management programs are available to help members with lifestyle changes and chronic condition support." },
                    { "Health and Wellness Discounts", "Your UPMC Health Plan membership gives you access to discounts such as the ChooseHealthy program and Active&Fit Direct." },
                    { "Reproductive health services", "You can go to a PCP or ob-gyn for preventive gynecological care. Coverage includes prenatal and postnatal support and preventive screenings." },
                    { "Behavioral health services", "UPMC Health Plan provides behavioral health services including telephonic coaching and access to treatment resources for conditions like depression and anxiety." }
                },
                ChapterRightRowTitles = new List<string>
                {
                    "Find a participating provider/select your primary care provider",
                    "Schedule a wellness visit",
                    "Go paperless",
                    "Find a provider/select your primary care provider",
                    "No-cost PCP services",
                    "Download the UPMC Health Plan app.",
                    "Schedule a wellness visit",
                    "Go paperless",
                    "Questions?",
                    "Use MyUPMC.com or the MyUPMC app to review information about the care you've received from UPMC providers.",
                    "Reviewing your plan documents",
                    "Preventive Services",
                    "PREVENTIVE VERSUS DIAGNOSTIC: WHAT’S THE DIFFERENCE?",
                    "Here's how the claims process works after you receive care:",
                    "Your network",
                    "Your plan",
                    "Here is what you need to know about your UPMC Advantage EPO plan:",
                    "Here is what you need to know about your Extended Network PPO plan:",
                    "Using the Cigna Healthcare PPO Network",
                    "Your member ID card is the key to your care",
                    "Find the Right Care at the Right Time",
                    "Review your care options",
                    "Emergency room",
                    "Global emergency travel assistance services",
                    "Care while travelling (extended network)",
                    "Personal Representative Designation Form",
                    "Transition of care",
                    "Being able to hear well is critical to your overall health.",
                    "Your UPMC Health Plan medical coverage gives you and your eligible dependents access to savings on hearing health care devices. The hearing health benefit will further reduce the cost of those devices and help you save on services:",
                    "Take the first step: Get care from a participating provider",
                    "Learn the details of your hearing health care benefit",
                    "Prescription drug coverage",
                    "Request a pharmacy review",
                    "Home delivery",
                    "There are four ways to sign up for home delivery:",
                    "Retail",
                    "You're not in this alone.",
                    "Take a Healthy Step (TAHS)",
                    "Customized help for you",
                    "To get started, choose one of the following options:",
                    "Active&Fit Direct Program",
                    "Lasik Eye Procedure Discounts",
                    "Amplifon Hearing Aid Benefit",
                    "Obstetrical or gynecological care",
                    "Preventive screenings",
                    "Family planning",
                    "Fertility Assistance",
                    "Baby Steps",
                    "Support for breastfeeding",
                    "Behavioral health services",
                    "Support in an emergency",
                    "Use MyUPMC.com and the MyUPMC app to review information about the care you've received from UPMC providers.",
                    "Have questions?",
                    "Need help with UPMC Health Plan's digital tools?",
                    "Paying for your health care and plan documents",
                    "Here is what you need to know about a PPO plan:",
                    "Primary care providers",
                    "UPMC MyHealth 24/7 Nurse Line",
                    "24/7 Video Visits",
                    "Get quality virtual care at a low cost",
                    "UPMC-GoHealth Urgent Care",
                    "Emergency assistance",
                    "Extended network for care while traveling",
                    "Health Coaching",
                    "The ChooseHealthy® Program",
                    "ACTIVE&FIT DIRECT PROGRAM",
                    "Program benefits:",
                    "LASIK and Hearing Aid Discounts",
                    "LASIK Eye Procedure Discounts",
                    "Amplifon Hearing Aid Discounts",
                    "We offer these free telephonic behavioral health coaching programs:",


                },
                ChapterDescriptionItems =  new List<string>{
                    "Program areas include:\r\nWeight management.\r\nPhysical Activity.\r\nTobacco cessation.\r\nStress management.\r\nNutrition basics.\r\nDiabetes prevention.\r\nHealthy families.\r\nSleep.",
                    "Sleep.",
                    "Diabetes.",
                    "Personal care plan",
                        "$0 annual well-visits for adults and children",
                        "$0 preventive screenings",
                        "$0 flu shots and other required immunizations",
                        "Coordinate your care when you are seeing multiple providers",
                        "Referrals to $0 health coaching for lifestyle changes or chronic condition management",
                        "Referrals to other participating providers or specialists",
                        "Access your plan details, medical claims, spending activity, and other digital tools.",
                        "View and download digital ID cards for yourself and your covered family members.",
                        "Find care, search for participating providers, select your primary care provider, and call a nurse at the UPMC MyHealth 24/7 Nurse Line.",
                        "Access urgent care, counseling resources, health coaches, and more.",
                        "Chat with, call, or send a message to a Health Care Concierge or health coach.",
                        "View your wellness resources and incentives (if applicable).",
                        "Identify potential health issues.",
                        "Make sure you are up to date on your screenings and immunizations.",
                        "Learn about any changes in your life or health.",
                        "Screen for behavioral health concerns.",
                        "Call your PCP to schedule a visit during a time that works for you.",
                        "Use the MyUPMC app. After you log in, select Appointments, then pick a date and time that fits your schedule. This is applicable for UPMC providers only.",
                        "App: Go to Account, then Preferences.",
                        "Member site: select Profile Settings, then scroll down to Communication Preferences",
                        "Get answers to benefits questions and learn how your health plan works.",
                        "Help you find a provider and schedule an appointment.",
                        "Learn whether a prescription drug is covered (if applicable).",
                        "Connect you to a nurse for answers to health-related questions.",
                        "Estimate your out-of-pocket costs for procedures based on your plan.",
                        "Help you access online and digital tools, including UPMC AnywhereCare and MyUPMC.",
                        "Answer your billing or coverage questions.",
                        "Communicate with your UPMC providers.",
                        "Schedule and manage in-person and virtual appointments.",
                        "View your medical record, providers' notes, and test results.",
                        "Renew your prescriptions.",
                        "Pay bills you received from UPMC providers.",
                        "Explains your copayment, deductible, and coinsurance amounts, as well as your out-of-pocket maximum.",
                        "Lists health care services and their level of coverage.",
                        "You must stay within your network to receive coverage for your care. The only exception is emergency care. In an emergency, you can visit any emergency department, even if the hospital does not participate with UPMC Health Plan. Emergency care will be covered at the highest benefit level, no matter where you are or which emergency department you visit.",
                        "Your network and benefits are tiered for facility-based services. You have Level 1 access to the UPMC Advantage Network. It includes all professional providers that participate with UPMC Health Plan, all UPMC-owned facilities, and other facilities designated as Level 1. Your out-of-pocket costs may be higher if you receive care from a UPMC Health Plan Network (Level 2) facility. Level 2 providers are usually a broader network of contracted providers who accept UPMC Health Plan insurance.",
                        "You do not need a referral to see a specialist.",
                        "It is important to select a primary care provider (PCP). Your PCP will get to know you and your health, then help you get appropriate preventive care, refer you to specialists when necessary, and coordinate any other care you need.",
                        "You have Level 1 access to the UPMC Advantage Network; the UPMC Health Plan Network; and the extended network, which includes providers that participate with the SuperMed PPO Network in Ohio and the Cigna Healthcare℠ PPO Network outside our Pennsylvania service area and Ohio.",
                        "You have Level 2 coverage for nonparticipating providers, but your out-of-pocket costs may be higher.",
                        "You do not need a referral to see a specialist.",
                        "Go to the UPMC Health Plan member site home screen > Quick Links > Print or order an ID card",
                        "Download the free UPMC Health Plan app > Sign in > under the Insurance tab, navigate to ID Card",
                        "Call 911.",
                        "Call 988 for the Suicide and Crisis LifeLine.",
                        "Call your local ambulance service.",
                        "Go to the nearest emergency room. After you are discharged, contact your PCP as soon as possible to schedule follow-up care.",
                        "An allowance for hearing exams, hearing aids, and accessories every 36 months",
                        "One year of free follow-up care",
                        "A two-year supply of free batteries or one charging station",
                        "A three-year warranty covering manufacturing defects and a one-time replacement of the device in the event of loss or damage (deductible applies)",
                        "A 60-day return policy for a full refund if you are not completely satisfied",
                        "Up to six no-cost, confidential coaching and counseling sessions for various issues, including emotional challenges, stress, depression, relationships, and work-related concerns. Sessions can be held virtually, in person, over the phone, or via text message or chat (available to members who are 14 years or older).",
                        "No-cost consultations related to financial wellness or legal issues.",
                        "Referrals to community resources.",
                        "Access to an interactive website that contains professional and personal development resources.",
                        "Weight management.",
                        "Physical Activity.",
                        "Tobacco cessation.",
                        "Stress management.",
                        "Nutrition basics.",
                        "Diabetes prevention.",
                        "Healthy families.",
                        "Cardiovascular health.",
                        "Respiratory health.",
                        "Behavioral health.",
                        "Chronic pain.",
                        "The Baby Steps maternity health coaching program.",
                        "Pediatric care management.",
                        "Case management.",
                        "Optional surgeries such as hip, knee, or bariatric surgery.",
                        "Condition or pain management.",
                        "Cancer treatment.",
                        "For a virtual visit, select Video Visit under the care tab. To start by phone, call 1-844-822-3367 (TTY: 711). Help is available Monday through Friday from 8 a.m. to 7 p.m. and Saturday from 8 a.m.to 3 p.m.",
                        "Access more than 12,700 fitness centers, with the ability to change anytime",
                        "Access more than 12,000 digital workout videos so you can work out at home or on the go",
                        "No long-term contract",
                        "QualSight LASIK",
                        "TLC Laser Eye Centers",
                        "UPMC Eye Center",
                        "LASIK Centers of America",
                        "$2,000 benefit every 36 months, for children and adults.",
                        "Access to Amplifon's national network of hearing health providers.",
                        "A 60-day risk-free trial.",
                        "Breast cancer screenings (mammograms)",
                        "Cervical cancer screenings",
                        "Chlamydia screenings",
                        "Bone density screenings",
                        "Pre- and postnatal care and support",
                        "Counseling on pregnancy spacing",
                        "Birth control options",
                        "Medications that are safe to take while pregnant",
                        "Signs of complications and when to call a doctor",
                        "Pain relief options during labor",
                        "Baby care basics",
                        "The benefits of breast-feeding and how to continue after returning to work",
                        "Substance use.",
                        "Bereavement issues.",
                        "Marital or family concerns.",
                        "Health coaching support.",
                        "Refer you to an emergency department.",
                        "Dispatch a mobile crisis team.",
                        "Help you get an appointment within 24 hours.",
                        "Find care, search for participating providers, select your primary care provider, and call a nurse with the UPMC MyHealth 24/7 Nurse Line.",
                        "Access 24/7 video visits to get the virtual care you and your family need for nonemergency conditions.",
                        "$0 flu shot",
                        "Make sure you are up to date on your screenings and vaccinations.",
                        "Review any changes in your life or health.",
                        "Review your mental and behavioral health.",
                        "Use the MyUPMC app. After you log in, select Appointments, then pick a date and time that fit your schedule. This is applicable for UPMC providers only.",
                        "Member site: select Profile Settings, then scroll down to Communication Preferences.",
                        "Schedule and manage your in-person and virtual appointments.",
                        "Pay bills you've received from UPMC providers.",
                        "Get select information about your health plan.",
                        "Get help finding a provider in your network.",
                        "Determine whether a prescription drug is covered (if applicable).",
                        "Learn about preventive services you may need.",
                        "And more!",
                        "You will receive the highest level of benefits when you get care from participating providers. You can go to nonparticipating providers for care, but you will have to pay more out-of-pocket. The only exception is emergency care. In an emergency, you can visit any emergency department, even if the hospital does not participate with UPMC Health Plan. Your care will be covered at the highest benefit level.",
                        "Emergency medical evaluation",
                        "Medical monitoring and referrals",
                        "Medical repatriation",
                        "Foreign hospital admission assistance",
                        "Prescription assistance",
                        "Condition management topics include but are not limited to:\r\nDiabetes.\r\nCardiovascular health.\r\nRespiratory health.\r\nBehavioral health.\r\nChronic pain.",
                        "Access more than 12,200+ fitness centers, with the ability to change anytime",
                        "Access more than 9,300+ digital workout videos so you can work out at home or on the go",
                        "A patient care advocate will answer any questions you have and help you make an appointment.",
                        "Amplifon will send information about the program and what to expect at your hearing appointment.",
                        "Bone density testing",
                        "Medications that are safe to take while pregnant.",
                        "Signs of complications and when to call a doctor.",
                        "Pain relief options during labor.",
                        "Baby care basics.",
                        "The benefits of breastfeeding and how to continue after returning to work.",
                        "Depression",
                        "Anxiety",
                        "Pain and grief management",
                        "Attention-deficit/hyperactivity disorder (ADHD)",
                        "Substance use",
                       


                },
                ChapterRightRowDescriptions = new List<string>
                {
                    "It's important to choose a primary care provider (PCP) who participates with UPMC Health Plan.",
                    "Having a wellness visit with your primary care provider (PCP) is essential for staying on top of your health.",
                    "When you choose to get your plan materials online, you have safe and easy access to your documents 24/7."
                },
                ChapterSubheaderLinks = new List<string>
                {
                    "/external?externalUrl= https://www.upmcmyhealthmatters.com/health-break-why-its-important-to-choose-and-maintain-a-pcp&amp;window_target=blank",
                    "/external?externalUrl=https://smart.link/viv76xx4apl2t&amp;window_target=blank",
                    "/profile-settings",
                    "/external?externalUrl= https:%2F%2Ffindcare.upmchealthplan.com%2Ffindpcp&amp;ami=true&amp;at=true&amp;use_hash=true&amp;window_target=blank"
                },
                ChapterListItems = new List<string>
                {
                    "Personal care plan",
                    "$0 annual well-visits for adults and children",
                    "$0 preventive screenings",
                    "$0 flu shots and other required immunizations",
                    "Virtual primary care practices",
                    "Offers virtual visits",
                    "Accepting new patients",
                    "Coordinate your care when you are seeing multiple providers",
                    "Referrals to $0 health coaching for lifestyle changes or chronic condition management",
                    "Referrals to other participating providers or specialists"
                },

                Footnotes = new Dictionary<string, string>
                {
                    { "communication-preferences", "If you change your preferences to paperless, you will no longer receive some plan documents in the mail." },
                    { "chat-call", "UPMC Health Plan earned seven Stevie® Awards in 2025, including three Gold Stevie Awards for Customer Service Department of the Year—Healthcare, Pharmaceuticals, and Related Industries; Customer Service Employer of the Year; and Back-Office Customer Service Team of the Year. In 2024, the Health Plan earned a prestigious Grand Stevie Award." },
                    { "providers", "MyUPMC is available only to UPMC patients. Your health information will not appear in MyUPMC if you receive care from participating providers who are outside of the UPMC system." }
                },

                PopupTitle = "Enter your email address to continue",
                PopupBody = "Your email address will be used to access AnywhereCare.",
                PopupContinueButtonText = "Continue",

                ChatbotStartButtonText = "Start Chat",
                ChatbotBotMessages = new List<string>
                {
                    "I'm experiencing delays connecting to our services right now.",
                    "Please try again in a moment, or type \"help\" if you need immediate assistance."
                },
                ChatInputPlaceholder = "Type a message",
                ChatSendButtonText = "Send",

                FooterCopyrightText = "Copyright 2026 UPMC Health Plan, Inc.",
                FooterLinkGroups = new Dictionary<string, string[]>
                {
                    { "About Website", new[] { "/external?externalUrl=https://www.upmchealthplan.com/legal/terms-and-conditions", "/external?externalUrl=https://www.upmchealthplan.com/legal/privacy", "/external?externalUrl=https://content.upmchp.com/mhol/footer-pdf/24ISD4950898%20-%20Non-Discrimination%20Notice%20CM_MKT%20110424.pdf" } },
                    { "Visit", new[] { "/external?externalUrl=https://www.upmchealthplan.com/", "/external?externalUrl=https://www.upmc.com/" } },
                    { "Download Our Mobile App", new[] { "/external?externalUrl=https://apps.apple.com/us/app/upmc-health-plan/id540785586?ls=1", "/external?externalUrl=http://www.bit.ly/UPMCHPandroid" } }
                }
            };
        }
    }
}
