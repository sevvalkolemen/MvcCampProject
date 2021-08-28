using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCampProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }

        //MessageListMenu
        public PartialViewResult ContactPartial()
        {
            var contactList = cm.GetList().Count();
            ViewBag.contactList = contactList;

            //var messageList = _messageManager.GetListInbox(p).Count();
            //ViewBag.messageList = messageList;

            //var messageSend = _messageManager.GetListSendbox().Count();
            //ViewBag.messageSend = messageSend;

            var draft = _messageManager.GetAll().Where(x => x.IsDraft == true).Count();
            ViewBag.draft = draft;

            var readMessage = _messageManager.GetAll().Where(x => x.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = _messageManager.GetUnReadList().Count();
            ViewBag.unreadMessage = unreadMessage;

            return PartialView();
        }
    }
}