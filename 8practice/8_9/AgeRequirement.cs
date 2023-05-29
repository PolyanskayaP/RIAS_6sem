namespace _8_9
{
    using Microsoft.AspNetCore.Authorization;

    class AgeRequirement : IAuthorizationRequirement
    {
        protected internal int Age { get; set; }
        public AgeRequirement(int age) => Age = age;
    }
}
