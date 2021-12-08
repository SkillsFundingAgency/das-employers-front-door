﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using SFA.DAS.FindEmploymentSchemes.Web.Models;

namespace SFA.DAS.FindEmploymentSchemes.Web.Content
{
    public static class SchemesContent
    {
        public static readonly IEnumerable<Scheme> Schemes = new[]
        {
            // _    _                                _
            //| |  | |                              | |
            //| |__| | ___ _   _   _   _  ___  _   _| |
            //|  __  |/ _ \ | | | | | | |/ _ \| | | | |
            //| |  | |  __/ |_| | | |_| | (_) | |_| |_|
            //|_|  |_|\___|\__, |  \__, |\___/ \__,_(_)
            //              __/ |   __/ |
            //              |___/   |___/
            //
            // these schemes are generated by the TestHarness from Contentful, so don't directly make changes here!!!
            //


            new Scheme("Apprenticeships",
                new HtmlString(
                    @"<p>Paid employment for over 16s, combining work and study in a job allowing you to develop your workforce and business.</p>"),
                new HtmlString(
                    @"<p>Apprentice minimum wage and 5% training contribution depending on business size</p>"),
                new HtmlString(@"<p>You develop a motivated, skilled, and qualified workforce</p>"),
                new HtmlString(@"<p>Minimum of 12 months employment</p>"),
                "apprenticeships", 403000,
                new string[]
                {
                    "pay--minimum-wage", "motivations--full-time-role", "motivations--diversity-or-responsibility",
                    "scheme-length--4-months-to-12-months", "scheme-length--a-year-or-more",
                },
                null,
                new HtmlString(
                    @"<p>Applies to England</p><p>Apprenticeships are for those aged 16 or over and combine working with studying to gain skills and knowledge in a job role.</p><p>Apprentices can be new or current employees.</p><p>Your apprentice must:</p><ul class =""govuk-list govuk-list--bullet""><li>work with experienced staff</li><li>learn skills relevant to your organisation</li><li>get time for training or study during their working week (at least 20% of their normal working hours)</li></ul><p></p>"),
                new HtmlString(
                    @"<p>You must pay apprentices <a href=""https://www.gov.uk/national-minimum-wage-rates"" title="""" class=""govuk-link"">the minimum wage</a>.</p><p>You may have to contribute 5% of the apprentice's training and assessment costs - depending on the size of your business and the age of your apprentice.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>an induction which includes explaining relevant policies and procedures</li><li>opportunities for the student to develop their technical skills within your industry</li><li>20% 'Off-the-job' training delivered by a training provider during your apprentice&#39;s normal working hours</li><li>'On-the-job' training and additional support to ensure your apprentice's success</li></ul><p>Employers must also have:</p><ul class =""govuk-list govuk-list--bullet""><li>a signed apprenticeship agreement and apprenticeship commitment statement from the learner and training provider</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Find out <a href=""https://www.apprenticeships.gov.uk/"" title="""" class=""govuk-link"">how apprenticeships can benefit your business</a>.</p>"),
                new HtmlString(
                    @"<p>Read about <a href=""https://www.apprenticeships.gov.uk/employers/real-stories-employers"" title="""" class=""govuk-link"">how businesses are using incentive payments to hire apprentices</a>.</p>"),
                "Offer an apprenticeship",
                new HtmlString(
                    @"<p>Get started with offering an apprenticeship.</p><p><a href=""https://www.apprenticeships.gov.uk/employers/hiring-an-apprentice"" title="""" class=""govuk-link"">Hire an apprentice</a></p><p>Alternatively, call <a href=""tel:08000150400"" title="""" class=""govuk-link"">08000 150 400</a></p>")
            ),
            new Scheme("T Levels: industry placements",
                new HtmlString(
                    @"<p>Provide a 45 day (315 hours) industry placement for 16 to 19 year-olds, which gives you early access to the brightest entering the market and the opportunity to develop your workforce of the future.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs</p>"),
                new HtmlString(@"<p>Industry placements can save on many of the costs associated with recruitment</p>"),
                new HtmlString(@"<p>Short term 45-day industry placement</p>"),
                "t-levels-industry-placements", 72000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>T Levels are qualifications for students aged 16 to 19 who have finished GCSEs. They are a 2-year qualification and the equivalent to 3 A levels.</p><p>They have been designed with employers, to give them the skilled workforce they need by helping young people develop their knowledge, attitude and practical skills to thrive in the workplace.</p>"),
                new HtmlString(
                    @"<p>Free government scheme but you may have your own business costs.</p><p>Some employers may choose to pay wages and cover expenses such as travel and living costs.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>opportunities for the student to develop their technical skills within your industry</li><li>a line manager to support, supervise and mentor the student</li><li>an induction which includes explaining relevant policies and procedures</li><li>formal feedback on the student's progress against the agreed learning goals at the end of the placement</li></ul><p></p>"),
                new HtmlString(
                    @"<p>T Levels are available in more than 20 courses, covering 11 skill areas.</p><p>T Levels can support:</p><ul class =""govuk-list govuk-list--bullet""><li>you to build a pipeline of entry-level positions</li><li>the next generation of workers entering your industry to succeed</li><li>you with recruitment, improve innovation and increase your organisation's productivity</li><li>you to fill skills shortages&#160;</li><li>your local community and improve diversity</li><li>your existing staff gain management and mentoring skills</li></ul><p>Find out <a href=""https://www.tlevels.gov.uk/employers"" title="""" class=""govuk-link"">how T Levels can benefit your business</a>.

</p>"),
                new HtmlString(
                    @"<p>Read about <a href=""https://www.gov.uk/government/case-studies/how-employers-are-benefitting-from-t-level-industry-placements"" title="""" class=""govuk-link"">how businesses are using T Levels industry placements</a>.</p>"),
                "Offer an industry placement",
                new HtmlString(
                    @"<p>Get started with offering an industry placement.</p><p><a href=""https://employers.tlevels.gov.uk/hc/en-gb/requests/new"" title="""" class=""govuk-link"">Take the next steps with T Levels</a></p><p>Alternatively, call <a href=""tel:08000150600"" title="""" class=""govuk-link"">08000 150 600</a> (choose option 4)</p>")
            ),
            new Scheme("Sector-based Work Academy Programme (SWAP)",
                new HtmlString(
                    @"<p>Up to 6-week placement for benefit claimants aged 18+ designed to help you recruit a workforce with the right skills to sustain and grow your business.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs</p>"),
                new HtmlString(@"<p>Helps you recruit or train staff through fully-funded pre-employment training</p>"),
                new HtmlString(@"<p>Up to 6-weeks</p>"),
                "sector-based-work-academy-programme-swap", 70000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role", "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>Sector-based Work Academy Programmes (SWAPs) help prepare those receiving unemployment benefits to apply for jobs in a different area of work.</p><p>Placements run up to 6 weeks and are designed to help you recruit a workforce with the right skills to sustain and grow your business.</p><p>They are tailored to meet your recruitment needs, including pre-employment training, a work experience placement, and your guarantee of a job interview for participants.</p><p>Jobcentre Plus manages SWAPs in England and Scotland.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs.</p>"),
                new HtmlString(
                    @"<p>In order for both businesses and individuals to benefit from the work experience placement, Jobcentre Plus will ask that you:</p><ul class =""govuk-list govuk-list--bullet""><li>explain what you need the scheme's participants to do</li><li>inform them of management and reporting arrangements</li><li>encourage positive working relationships</li><li>provide an overview of your business and its values and culture</li><li>give a tour of the workplace</li><li>provide guidance on using any equipment</li><li>provide guidance on health and safety</li><li>explain standard workplace practices such as security procedures, dress code, sick leave and absences and break times</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Find out <a href=""https://www.gov.uk/government/publications/sector-based-work-academies-employer-guide/sector-based-work-academies-employer-guide"" title="""" class=""govuk-link"">how SWAP could benefit your business</a>.</p>"),
                new HtmlString(
                    @"<p>Read about <a href=""https://www.gov.uk/government/case-studies/how-employers-are-benefitting-from-sector-based-work-academies"" title="""" class=""govuk-link"">how employers are using sector-based work academy programmes</a>.</p>"),
                "Offer a SWAP",
                new HtmlString(
                    @"<p>Contact the Employer Services Line on <a href=""tel:08001690178"" title="""" class=""govuk-link"">0800 169 0178</a></p><p>They will put you in touch with a local Jobcentre Plus employer team.</p>")
            ),
            new Scheme("Skills Bootcamps",
                new HtmlString(
                    @"<p>Flexible work and training courses for over 19's to fast-track specialist skill development, for existing or new talent for your business.</p>"),
                new HtmlString(@"<p>No cost unless self-employed</p>"),
                new HtmlString(
                    @"<p>Helps future-proof your business in a rapidly changing labour market and recruit staff with the right training and skills from the outset</p>"),
                new HtmlString(@"<p>12 to 16-weeks</p>"),
                "skills-bootcamps", 68000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role",
                    "scheme-length--4-months-to-12-months", "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>Skills Bootcamps offer free, flexible courses of up to 16 weeks for adults aged 19 or over and who are either in work, self-employed, recently unemployed or returning to work after a break.</p><p>They give people the opportunity to build up valuable sector-specific skills based on local employer demand in areas including digital, construction and green skills.</p><p>They provide a direct path to a job on completion.</p>"),
                new HtmlString(
                    @"<p>Employers who want to use Skills Bootcamps for their existing employees contribute 30% of the cost.</p><p>Existing employees may need time to study and attend classes depending on their working hours and status and the flexibility of the course.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>an induction which includes explaining relevant policies and procedures</li><li>a line manager to support, supervise and mentor the student</li><li>a guaranteed interview as part of the Skills Bootcamp provision</li></ul><p></p>"),
                new HtmlString(
                    @"<p>They help you:</p><ul class =""govuk-list govuk-list--bullet""><li>develop a loyal and talented workforce with the skills you need</li><li>futureproof your business in a rapidly changing labour market</li><li>improve your productivity; learners are motivated to learn new skills, provide new ideas and a fresh perspective</li><li>recruit staff with the right training and skills from the outset</li><li>get access to a pipeline of skilled adults at no cost by working with existing Skills Bootcamp providers </li></ul><p></p>"),
                null,
                "Offer a Skills Bootcamps",
                new HtmlString(
                    @"<p>Get started with offering Skills Bootcamps and find providers offering courses in your area.</p><p><a href=""https://www.gov.uk/government/publications/find-a-skills-bootcamp"" title="""" class=""govuk-link"">Find Skills Bootcamps in your area</a></p>")
            ),
            new Scheme("Traineeships",
                new HtmlString(
                    @"<p>A 6-week to 12 months skills development programme that includes an unpaid work placement to help 16- to 24-year-olds prepare for an apprenticeship or employment.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs</p>"),
                new HtmlString(
                    @"<p>Helps you increase your capacity and productivity whilst developing a loyal and talented workforce</p>"),
                new HtmlString(@"<p>70 to 240 hours work placement</p>"),
                "traineeships", 43000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role",
                    "scheme-length--4-months-to-12-months", "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>A traineeship is a skills development programme that includes a work placement.</p><p>The full programme can last from 6 weeks up to 1 year, though most traineeships last for between 6-weeks and 12-weeks.</p><p>Your business needs to be able to offer a safe, meaningful and high-quality work experience placement of at least 70 hours to 240 hours.</p><p>You will work with a training provider to design what is included in the programme.</p><p>The trainee will gain English, maths, digital and work-related qualifications which can lead them on to:</p><ul class =""govuk-list govuk-list--bullet""><li>an apprenticeship</li><li>work</li><li>further education</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Free government scheme but you may have your own business costs.</p><p>Some employers may choose to pay the wages and any payments for expenses such as travel and living costs.
</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe, meaningful and high-quality work experience placement</li><li>a minimum of 70 hours of work experience placement over the duration of the traineeship (if the trainee claims benefits, the placement cannot last longer than 240 hours)</li><li>constructive feedback and advice to the trainee</li><li>an interview for an apprenticeship or job in their organisation at the end of the traineeship if one is available</li><li>an exit interview at the end of the traineeship with meaningful written feedback if no job is available</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Traineeships have seen big increases as businesses recover from the pandemic and are expected to double to around 40,000 per year.</p><p>Find out <a href=""https://www.gov.uk/guidance/traineeship-information-for-employers"" title="""" class=""govuk-link"">how traineeships can benefit your business</a>.</p>"),
                new HtmlString(
                    @"<p>Read about <a href=""https://www.gov.uk/government/case-studies/how-employers-are-benefitting-from-traineeships"" title="""" class=""govuk-link"">how businesses are using traineeships</a>.</p>"),
                "Offer a traineeship",
                new HtmlString(
                    @"<p>Get started with offering a traineeship.</p><p><a href=""https://www.gov.uk/guidance/traineeship-information-for-employers#get-started"" title="""" class=""govuk-link"">Contact the National Apprenticeship Service</a></p><p>Alternatively, call <a href=""tel:08000150600"" title="""" class=""govuk-link"">08000 150 600</a></p>")
            ),
            new Scheme("Supported Internships for learners with an education, health and care plan",
                new HtmlString(
                    @"<p>An unpaid 6 to 12-month work placement for 16 to 24-year-olds with additional needs supported by a qualified job coach.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs.</p>"),
                new HtmlString(
                    @"<p>Allows you to shape a job role that suits your business and the needs of the supported intern and increases your confidence of employing individuals with additional needs</p>"),
                new HtmlString(@"<p>6 to 12-months</p>"),
                "supported-internships-for-learners-with-an-education-health-and-care-plan", 20000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role",
                    "scheme-length--4-months-to-12-months",
                },
                null,
                new HtmlString(
                    @"<p>Supported internships are a work-based study programme for young people aged 16 to 24 with Special Educational Needs and Disabilities (SEND), who have an <a href=""https://www.gov.uk/children-with-special-educational-needs/extra-SEN-help"" title="""" class=""govuk-link"">education health and care (EHC) plan</a>.</p><p>Supported internships equip young people with the skills they need to secure and sustain employment through learning in the workplace, with support from a qualified job coach. They last between 6 to 12 months.</p><p>Supported interns are enrolled with and supported by a learning provider, but spend most of their learning time - typically around 70% in the workplace.</p><p>Alongside their time with the employer, supported interns complete a personalised study programme delivered by the school/college, which includes the chance to study for relevant qualifications, if appropriate, and English and maths at an appropriate level.</p>"),
                new HtmlString(
                    @"<p>Free government scheme but you may have your own business costs.</p><p>Some employers may choose to pay wages and cover expenses such as travel and living costs.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>workplaces adjustments the supported intern may need</li><li>a line manager to support, supervise and mentor the student</li><li>an induction which includes explaining relevant policies and procedures</li><li>a welcoming environment and be willing to work collaboratively with the job coach, to support the young person to succeed</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Supported internships:</p><ul class =""govuk-list govuk-list--bullet""><li>create and support a diverse workforce</li><li>provide a job coach who will support the intern and increase your confidence of employing individuals with additional needs</li><li>increase your capacity and productivity</li><li>allows you to shape a job role that suits both the needs of your business and the needs of the supported intern</li></ul><p></p>"),
                null,
                "Offer a supported internship",
                new HtmlString(
                    @"<p>Offer a Supported Internship by contacting the lead for your region from the <a href=""https://www.preparingforadulthood.org.uk/about-us/meet-the-team.htm#Regional%20Leads"" title="""" class=""govuk-link"">Preparing for Adulthood Team</a></p>")
            ),
            new Scheme("Care-Leaver covenant",
                new HtmlString(
                    @"<p>Help 16 to 25-year-olds who were in local authority care become independent through practical job-related support, in whatever way suits your business.</p>"),
                new HtmlString(
                    @"<p>Free government scheme but you may have your own business costs related to the practical offer you make to care leavers</p>"),
                new HtmlString(
                    @"<p>Helping care-leavers to move to independent living and bring their life skills to enrich your business</p>"),
                new HtmlString(@"<p>Length of time can vary</p>"),
                "care-leaver-covenant", 2000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role", "scheme-length--a-year-or-more",
                    "scheme-length--4-months-to-12-months", "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>The Care-leaver Covenant is a way companies can support 16 to 25-year-olds leaving care to become independent.</p><p>Organisations can pledge support including apprenticeships, work experience or free or discounted goods or services. About the CLC - Care Leaver Covenant (mycovenant.org.uk)</p>"),
                new HtmlString(
                    @"<p>You may have your own business costs related to the practical offer your business makes to care leavers.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>an induction which includes explaining relevant policies and procedures</li><li>practical help that makes a difference to the life of a care leaver</li></ul><p></p>"),
                new HtmlString(@"<p>You create and support a diverse and loyal workforce for your business.</p>"),
                new HtmlString(
                    @"<p>Read how <a href=""https://mycovenant.org.uk/covenant-stories/"" title="""" class=""govuk-link"">companies have been making a difference to the lives of care leavers</a></p>"),
                "Offer a Care Leavers Covenant",
                new HtmlString(
                    @"<p><a href=""https://mycovenant.org.uk/support-the-covenant/organisation-sign-up/"" title="""" class=""govuk-link"">Find out how to join the Care Leavers Covenant</a> and tailor what opportunities your business would like to offer to care leavers.</p><p>Alternatively, contact the Care Leavers Covenant via telephone on <a href=""tel:08000773557"" title="""" class=""govuk-link"">0800 077 3557</a>.</p>")
            ),
            new Scheme("Employing prisoners and prison leavers",
                new HtmlString(
                    @"<p>Employ prisoners and prison leavers aged 18+ to help your business fill skills gaps and develop a loyal and talented workforce.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs</p>"),
                new HtmlString(@"<p>Helping prisoners and prison leavers find employment</p>"),
                new HtmlString(@"<p>Variable depending on employer and prisoner and prison leaver</p>"),
                "employing-prisoners-and-prison-leavers", 1000,
                new string[]
                {
                    "pay--minimum-wage", "motivations--diversity-or-responsibility", "motivations--full-time-role",
                    "scheme-length--a-year-or-more", "scheme-length--4-months-to-12-months",
                    "scheme-length--up-to-4-months",
                },
                null,
                new HtmlString(
                    @"<p>New Futures Network (NFN) arranges partnerships between prisons and employers in England and Wales. These partnerships help you:</p><ul class =""govuk-list govuk-list--bullet""><li>fill skills gaps in your business</li><li>reduce recruitment costs</li><li>increase staff retention</li><li>transform prison leavers lives</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Free government scheme but you may have your own business costs. If you recruit someone you must pay <a href=""https://www.gov.uk/national-minimum-wage-rates"" title="""" class=""govuk-link"">the minimum wage</a>.</p>"),
                new HtmlString(
                    @"<p>Employers must provide:</p><ul class =""govuk-list govuk-list--bullet""><li>a safe work environment</li><li>a line manager to support, supervise and mentor</li><li>an induction which includes explaining relevant policies and procedures</li></ul><p></p>"),
                new HtmlString(
                    @"<p>Over 400 businesses already work in partnership with prisons to provide work and employment opportunities.</p><p>Of those surveyed, more than 80% of employers positively rated those they employed as reliable and hard-working.</p>"),
                new HtmlString(
                    @"<p>Read about <a href=""https://newfuturesnetwork.gov.uk/case-studies/#"" title="""" class=""govuk-link"">how businesses are working with serving prisoners and hiring prison leavers</a>.</p>"),
                "Offer prisoners and prison leavers employment",
                new HtmlString(
                    @"<p><a href=""https://newfuturesnetwork.gov.uk/register/"" title="""" class=""govuk-link"">Register your interest on the New Futures Network</a>.</p><p>A member of the team will be in touch to discuss the process.</p>")
            ),
            new Scheme("Higher Technical Qualifications (HTQs)",
                new HtmlString(
                    @"<p>Level 4 or 5 qualifications, for over 18s, with no work placement but flexible for employees to study while working.</p>"),
                new HtmlString(@"<p>Free government scheme but you may have your own business costs</p>"),
                new HtmlString(
                    @"<p>Developed by employers to upskill existing employees, provide a different recruitment pool to hire new talent and help your company succeed</p>"),
                new HtmlString(@"<p>1 to 2 years</p>"),
                "higher-technical-qualifications", -500,
                new string[] {"pay--minimum-wage", "motivations--full-time-role", "scheme-length--a-year-or-more",},
                null,
                new HtmlString(
                    @"<p>Higher Technical Qualifications (HTQs) are a high-quality addition to technical training routes, alongside apprenticeships, traineeships and degrees.</p><p>They are:</p><ul class =""govuk-list govuk-list--bullet""><li>new and existing Level 4 and 5 qualifications (such as Higher National Diplomas, Foundation Degrees, Diploma Higher Education)</li><li>approved by the Institute for Apprenticeships and Technical Education, against employer-led occupational standards</li></ul><p>The first Digital HTQs will be available for teaching from 2022, leading to higher-level occupations like Network Engineer, Software Developer and Data Analyst.</p><p>Health and Science and Construction qualifications will be available for teaching from 2023, with a full roll-out of further industrial sectors over a four-year period.</p>"),
                new HtmlString(
                    @"<p>You may choose to pay for an employee to undertake a HTQ. Costs will vary depending on the course and provider.</p>"),
                new HtmlString(@"<p>Most HTQs do not require an in-work placement.</p>"),
                new HtmlString(
                    @"<p>HTQs have been developed by employers and awarding bodies to help you upskill existing employees and provide a different recruitment pool to hire new talent.</p><p>They help your workforce have the right knowledge, skills and behaviours for your company to succeed.</p>"),
                null,
                "Offer HTQs",
                new HtmlString(
                    @"<p><a href=""https://www.gov.uk/guidance/htqs"" title="""" class=""govuk-link"">Learn more and get started with HTQs</a>.</p>")
            ),
            new Scheme("Training outside of employment",
                new HtmlString(
                    @"<p>Additional ways to train up existing employees through free qualifications, career advice and financial support.</p>"),
                new HtmlString(
                    @"<p>Courses are fully funded for eligible adults but employees may need time to study and attend classes</p>"),
                new HtmlString(
                    @"<p>Help improve productivity, and develop a loyal and talented workforce in a rapidly changing labour market</p>"),
                new HtmlString(@"<p>Length of time can vary</p>"),
                "training-outside-of-employment", -1000,
                new string[]
                {
                    "pay--unpaid", "pay--minimum-wage", "motivations--diversity-or-responsibility",
                    "motivations--unpaid-placement", "motivations--full-time-role", "scheme-length--a-year-or-more",
                    "scheme-length--4-months-to-12-months", "scheme-length--up-to-4-months",
                },
                new HtmlString(
                    @"<p>Career advice, free level 3 qualifications, and financial support for level 4 and 5 qualifications are all available through Government initiatives for your workforce.</p><h2 class=""govuk-heading-l"">Free qualifications for adults</h2><p><a href=""https://www.gov.uk/guidance/free-courses-for-jobs"" title="""" class=""govuk-link"">Free level 3 qualifications</a> are government-funded courses for any adult aged 19 and over, who are looking to achieve their first full level 3 qualification or earning below national minimum wage.</p><p>A full level 3 qualification is equivalent to an advanced technical certificate, diploma, or A levels.</p><p>Without needing to fund the training yourself, they help you:</p><ul class =""govuk-list govuk-list--bullet""><li>develop the talent pool in your business</li><li>progress your current employees into higher skilled roles</li></ul><p>The <a href=""https://www.gov.uk/guidance/free-courses-for-jobs"" title="""" class=""govuk-link"">Free Courses for jobs</a> offer and the qualification list has been developed with industry, and will be regularly reviewed. </p><h3 class=""govuk-heading-m"">Benefits of free level 3 qualifications</h3><p>Read the <a href=""https://learning.linkedin.com/content/dam/me/business/en-us/amp/learning-solutions/images/workplace-learning-report-2019/pdf/workplace-learning-report-2019.pdf"" title="""" class=""govuk-link"">LinkedIn Workplace Learning</a> report 2019 for information on developing a loyal and talented workforce.</p><div class=""cx-cta-box""><p>Offer free qualifications to adults</p><p>Upskill your workforce by helping your employees <a href=""https://www.gov.uk/government/publications/find-a-free-level-3-qualification"" title="""" class=""govuk-link"">find a free level 3 qualification</a>.</p></div><h2 class=""govuk-heading-l"">National Careers Service</h2><p>The National Careers Service can help you:</p><ul class =""govuk-list govuk-list--bullet""><li>explore work and skills opportunities for your workforce including those offered as part of the skills recovery package.</li><li>carry out skills needs analysis for your business to understand gaps and find solutions.</li><li>find skilled people to fill current vacancies in your organisation.</li></ul><h3 class=""govuk-heading-m"">Employer costs</h3><p>The National Careers Service is free to use.</p><h3 class=""govuk-heading-m"">Benefits of National Careers Service</h3><p>The National Careers Service can help you:</p><ul class =""govuk-list govuk-list--bullet""><li>futureproof your business for the future labour market</li><li>help to develop your current workforce and supplement with talented individuals who have the skills you need</li><li>increase your resilience and productivity</li><li>take part in national virtual jobs fairs</li></ul><div class=""cx-cta-box""><p>Use the National Careers Service to support your workforce</p><p>Find out more about the <a href=""https://nationalcareers.service.gov.uk/"" title="""" class=""govuk-link"">National Careers Service and how to contact them</a>.</p></div><p></p>"),
                null,
                null,
                null,
                null,
                null,
                "How to offer",
                null
            ),
        };

        public static readonly IEnumerable<MotivationsFilter> MotivationsFilters = new MotivationsFilter[]
        {

            new MotivationsFilter("motivations--full-time-role",
                "help train someone up into a full-time role"
            ),
            new MotivationsFilter("motivations--unpaid-placement",
                "offer someone an unpaid work placement opportunity"
            ),
            new MotivationsFilter("motivations--diversity-or-responsibility",
                "diversify our workforce or for corporate and social responsibility"
            ),
        };

        public static readonly IEnumerable<PayFilter> PayFilters = new PayFilter[]
        {

            new PayFilter("pay--minimum-wage",
                "at least national minimum wage"
            ),
            new PayFilter("pay--unpaid",
                "unpaid placements"
            ),
        };

        public static readonly IEnumerable<SchemeLengthFilter> SchemeLengthFilters = new SchemeLengthFilter[]
        {

            new SchemeLengthFilter("scheme-length--up-to-4-months",
                "Up to 4 months"
            ),
            new SchemeLengthFilter("scheme-length--4-months-to-12-months",
                "4 months to 12 months"
            ),
            new SchemeLengthFilter("scheme-length--a-year-or-more",
                "A year or more"
            ),
        };

        public static readonly IEnumerable<Page> Pages = new[]
        {
            new Page("Cookies",
                "cookies",
                new HtmlString(
                    @"<h1 class=""govuk-heading-xl"">Details about our cookies</h1><p>This service website puts small files (known as &#39;cookies&#39;) onto your computer. These cookies are used to:</p><ul class =""govuk-list govuk-list--bullet""><li>help us understand how you use the website, so we can make improvements</li><li>remember what notifications you&#39;ve seen so you&#39;re not shown them more than once</li><li>temporarily store the selections you make</li></ul><p>Find out more about&#160;<a href=""https://ico.org.uk/your-data-matters/online/cookies/"" title="""" class=""govuk-link"">how to manage cookies</a>.</p><h2 class=""govuk-heading-l"">Cookies that measure website usage</h2><p>We use Google Analytics software (Universal Analytics) to collect anonymised information about how you use the service. We do this to help make sure the site is meeting the needs of its users and to help us make improvements. We do not allow Google to use or share the data about how you use this site. Google Analytics stores information about:</p><ul class =""govuk-list govuk-list--bullet""><li>how you got to the site</li><li>the pages you visit on this service and how long you spend on them</li><li>what you click on while you&#39;re visiting the site</li></ul><p>We may also set our own cookies to understand how people move through the site.</p><p></p>")
            ),
            new Page("Privacy Notice",
                "privacy-notice",
                new HtmlString(
                    @"<h1 class=""govuk-heading-xl"">Privacy notice</h1><h2 class=""govuk-heading-l"">Who we are</h2><p>This website is provided by the Education and Skills Funding Agency
(ESFA) which is a part of the Department for Education (DfE). For the
purpose of data protection legislation, the DfE is the data controller
for the personal data processed as part of this website.</p><p>We collect certain information or data about you when you use of this website if you
agree to it. This includes your IP address, details of which version of web browser
you used, information on you use the site, using cookies and page tagging
techniques to help us improve the website.</p><p>This helps us to improve the site by monitoring how you use it. We can't personally
identify you using your data.</p><h2 class=""govuk-heading-l"">Keeping your data secure</h2><p>We won't share your information with any other organisations for marketing, market
research or commercial purposes, and we don't pass on your details to other
websites.</p><h2 class=""govuk-heading-l"">Disclosing your information</h2><p>We may pass on your information if we have a legal obligation to do so, or if we have
to enforce or apply our terms of use and other agreements. This includes exchanging
information with other government departments for legal reasons.</p><h2 class=""govuk-heading-l"">Links to other websites</h2><p>This website contains links to other websites. This privacy policy only applies to this
website. If you go to another website from this one, read the privacy policy on that
website to find out what it does with your information.</p><h2 class=""govuk-heading-l"">Following a link to this website from another website</h2><p>If you come to this website from another website, we may receive personal
information about you from the other website. You should read the privacy policy of
the website you came from to find out more about this.</p>")
),
        };
    }
}