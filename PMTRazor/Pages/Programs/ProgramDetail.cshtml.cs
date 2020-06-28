using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PMT_DataLayer.Extended_Enitities;
using PMTRazor.Extention;
using PMTRazor.Pages;

namespace PMTRazor
{
    public class ProgramDetailModel : BaseModel
    {
        private readonly PMTEntityContext _pMTEntityContext;

        #region Properties
        public PMT_DataLayer.CustomModels.PMT_SubProgramLevel SubProgramLevel { get; set; }
        public List<PMT_DataLayer.CustomModels.PMT_TrainerDetails> TrainerDetails { get; set; }
        public string SubProgramName { get; set; }
        public string SubDescription { get; set; }
        public string SubLevelDescription { get; set; }

        public int TotalTrainerCount { get; set; }
        #endregion

        public ProgramDetailModel(PMTEntityContext context)
        {
            _pMTEntityContext = context;
        }
        public async Task OnGet(Guid id, string sendInquiry)
        {
            if (id != default(Guid))
            {
                var subProgramLevel = await _pMTEntityContext.PMT_SubProgramLevel.FirstOrDefaultAsync(s => s.SubProgramLevelID == id);
                if (subProgramLevel != null)
                {
                    SubProgramLevel = subProgramLevel;
                    await GetSubProgramName(subProgramLevel.SubProgramId);
                }
                else
                    SubProgramLevel = new PMT_DataLayer.CustomModels.PMT_SubProgramLevel();

                SubLevelDescription = SubProgramLevel.Description;
            }

            if (!string.IsNullOrEmpty(sendInquiry))
            {
                //SendMail(id);
            }
            ClearSendInquiryFields();
        }

        public async Task GetSubProgramName(Guid subProgramId)
        {
            var program = await _pMTEntityContext.PMT_SubPrograms.Where(s => s.SubProgramId == subProgramId).ToListAsync();
            if (program != null && program.Any())
            {
                SubDescription = program.FirstOrDefault().Description;
                SubProgramName = program.FirstOrDefault().SubProgramName;

                var trainerPrograms = await _pMTEntityContext.PMT_TrainerProgramDetails.Where(s => s.SubProgramLevelId == SubProgramLevel.SubProgramLevelID).ToListAsync();
                if (trainerPrograms.Any())
                {
                    var trainerIds = trainerPrograms.Select(s => s.TrainerId).Distinct();
                    var trainerDetails = await _pMTEntityContext.PMT_TrainerDetails.Where(p => trainerIds.Contains(p.TrainerId) && !p.IsDeleted).ToListAsync();
                    if (trainerDetails != null && trainerDetails.Any())
                    {
                        TrainerDetails = trainerDetails.Where(s => trainerIds.Contains(s.TrainerId)).ToList();
                    }

                    TotalTrainerCount = TrainerDetails.Count();
                }
            }
        }

        public void SendMail(Guid id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name :- " + UserName);
            sb.Append("\n\r");
            sb.Append("Email id :- " + UserEmail);
            sb.Append("\n\r");
            sb.Append("MessageBody :- " + MessageBody);

            SendHtmlFormattedEmail(UserEmail, SubjectName, sb.ToString());

        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(recepientEmail);
                mail.CC.Add("office@dhanakshiacademy.com");// );
                mail.To.Add("brijesh@dhanakshiacademy.com");
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("johnsmith310791@gmail.com", "nirag@321");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private string PopulateBody(string programName, string TrainerNames)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate/SendEnquirery.html");
            //Server.MapPath("~/EmailTemplate.htm")
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(fullPath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{ProgramName}", programName);
            body = body.Replace("{TrainerNames}", TrainerNames);
            return body;
        }

        #region SendEmailProperties
        [BindProperty]
        public string UserEmail { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string SubjectName { get; set; }
        [BindProperty]
        public string MessageBody { get; set; }
        [BindProperty]
        public Guid SubLevelProgramId { get; set; }

        public IActionResult OnPost()
        {
            if (SubLevelProgramId != default(Guid))
            {
                SendMail(SubLevelProgramId);
            }

            return new RedirectToPageResult("ProgramDetail", new { id = SubLevelProgramId });
        }

        private void ClearSendInquiryFields()
        {
            UserName = string.Empty;
            MessageBody = string.Empty;
            UserEmail = string.Empty;
        }

        #endregion

    }
}