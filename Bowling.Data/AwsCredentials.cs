using Amazon.Runtime;

namespace Bowling.Data
{
    public class AwsCredentials : AWSCredentials
    {
        public override ImmutableCredentials GetCredentials()
        {
            return new ImmutableCredentials("", "", null);
        }
    }
}