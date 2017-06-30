using BungBungShop.Data.Infrastructure;
using BungBungShop.Data.Repositories;
using BungBungShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Service
{
    public interface IFeedBackService
    {
        Feedback Create(Feedback feedback);
        void Save();
    }

    public class FeedBackService : IFeedBackService
    {
        private IFeedBackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedBackService(IFeedBackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
        }
        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Comit();
        }
    }
}
