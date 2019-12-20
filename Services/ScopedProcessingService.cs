
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using QandAn.Models;

internal class ScopedProcessingService : IScopedProcessingService
{
    private readonly ApplicationDbContext _dbContext;
    private IEmailSender _sender;
    private int executionCount = 0;
    
    public ScopedProcessingService(ApplicationDbContext dbContext, IEmailSender sender)
    {
        _dbContext = dbContext;
        _sender = sender;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            executionCount++;
            Question mostPopular = _dbContext.Questions
                                        .Include(u => u.Answers)
                                        .Where(u => DateTime.Now - u.QuestionCreateTime < TimeSpan.FromHours(1))
                                        .OrderByDescending(u => u.Answers.Count).FirstOrDefault();

            var url = mostPopular is null ? "null" : $"https://localhost:5001/Question/Index/{mostPopular.ID}";
            await _sender.SendEmailAsync("smolenska.aa20@gmail.com",
                                         "Most popular question", 
                                         $"The most poular question is {url}. From {DateTime.Now - TimeSpan.FromHours(1)} To {DateTime.Now}");

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}