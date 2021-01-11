using How2CSS.Core.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepo AnswerRepo { get; }
        ICSSTaskRepo CSSTaskRepo { get; }
        IHintRepo HintRepo { get; }
        IMetadataRepo MetadataRepo { get; }
        IQuestionRepo QuestionRepo { get; }
        ITagDistributionRepo TagDistributionRepo { get; }
        ITagRepo TagRepo { get; }
        ITaskDistributionRepo TaskDistributionRepo { get; }
        ITaskResultRepo TaskResultRepo { get; }
        //IUnitDistributionRepo UnitDistributionRepo { get; }
        IUnitRepo UnitRepo { get; }
        IUserRepo UserRepo { get; }
        IUserAchievementRepo UserAchievementRepo { get; }
        IAchievementDataRepo AchievementDataRepo { get; }
        ILevelRepo LevelRepo { get; }
        Task SaveChangesAsync();
    }
}
