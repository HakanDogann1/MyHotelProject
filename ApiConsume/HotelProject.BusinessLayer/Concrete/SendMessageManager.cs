﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void TAdd(SendMessage entity)
        {
            _sendMessageDal.Add(entity);
        }

        public void TDelete(SendMessage entity)
        {
           _sendMessageDal.Delete(entity);
        }

        public SendMessage TGetById(int id)
        {
           return _sendMessageDal.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessageDal.GetList();
        }

        public int TGetSendMessageCount()
        {
            return _sendMessageDal.GetSendMessageCount();
        }

        public void TUpdate(SendMessage entity)
        {
            _sendMessageDal.Update(entity);
        }
    }
}
