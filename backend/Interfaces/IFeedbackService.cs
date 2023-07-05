using AngularBigBang.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigBang.Interfaces
{
  public interface IFeedbackService
  {

    public  Task<List<Feedback>> GetFeedbacks();

    public Task<List<Feedback>> PostFeedback(Feedback feedback);
  }
}
