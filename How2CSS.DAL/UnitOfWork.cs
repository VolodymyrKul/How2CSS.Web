using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IRepositories;
using How2CSS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepo _userRepo;
        private IUserAchievementRepo _userAchievementRepo;
        private IAchievementDataRepo _achievementDataRepo;
        private ILevelRepo _levelRepo;
        private IAnswerRepo _answerRepo;
        private ICSSTaskRepo _cSSTaskRepo;
        private IHintRepo _hintRepo;
        private IMetadataRepo _metadataRepo;
        private IQuestionRepo _questionRepo;
        private ITagDistributionRepo _tagDistributionRepo;
        private ITagRepo _tagRepo;
        private ITaskDistributionRepo _taskDistributionRepo;
        private ITaskResultRepo _taskResultRepo;
        //private IUnitDistributionRepo _unitDistributionRepo;
        private IUnitRepo _unitRepo;
        private How2CSSDbContext _context;

        public UnitOfWork(How2CSSDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public IUserRepo UserRepo
        {
            get { return _userRepo ??= new UserRepo(_context); }
        }

        public IUserAchievementRepo UserAchievementRepo
        {
            get { return _userAchievementRepo ??= new UserAchievementRepo(_context); }
        }

        public IAchievementDataRepo AchievementDataRepo
        {
            get { return _achievementDataRepo ??= new AchievementDataRepo(_context); }
        }

        public ILevelRepo LevelRepo
        {
            get { return _levelRepo ??= new LevelRepo(_context); }
        }

        public IAnswerRepo AnswerRepo
        {
            get { return _answerRepo ??= new AnswerRepo(_context); }
        }

        public ICSSTaskRepo CSSTaskRepo
        {
            get { return _cSSTaskRepo ??= new CSSTaskRepo(_context); }
        }

        public IHintRepo HintRepo
        {
            get { return _hintRepo ??= new HintRepo(_context); }
        }

        public IMetadataRepo MetadataRepo
        {
            get { return _metadataRepo ??= new MetadataRepo(_context); }
        }

        public IQuestionRepo QuestionRepo
        {
            get { return _questionRepo ??= new QuestionRepo(_context); }
        }

        public ITagDistributionRepo TagDistributionRepo
        {
            get { return _tagDistributionRepo ??= new TagDistributionRepo(_context); }
        }

        public ITagRepo TagRepo
        {
            get { return _tagRepo ??= new TagRepo(_context); }
        }

        public ITaskDistributionRepo TaskDistributionRepo
        {
            get { return _taskDistributionRepo ??= new TaskDistributionRepo(_context); }
        }

        public ITaskResultRepo TaskResultRepo
        {
            get { return _taskResultRepo ??= new TaskResultRepo(_context); }
        }

        //public IUnitDistributionRepo UnitDistributionRepo
        //{
        //    get { return _unitDistributionRepo ??= new UnitDistributionRepo(_context); }
        //}

        public IUnitRepo UnitRepo
        {
            get { return _unitRepo ??= new UnitRepo(_context); }
        }
    }
}
