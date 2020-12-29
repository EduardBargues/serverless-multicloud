# serverless-multicloud
Is it possible to create a serverless service that is completely cloud-provider-agnostic? Let's try to answer this question together ;) ...

# How to use it
- Clone the repository
- Build project for aws: Execute build.aws.sh
- Deploy project on aws: Execute deploy.aws.sh

# What I did so far
- hello-world function deployed to aws.
- hello-world function deployed to azure.
- Add common domain logic as an extra visual studio project
- Use dependency injection to include domain logic in aws project
- Add specific repository projects for aws (use dynamodb)

# Next steps
- Use dependency injection to include domain logic in azure project
- Add specific repository projects for azure (use table-storage)

# Issues
- https://forum.serverless.com/t/azure-csharp-template-authlevel-issue/13523?u=eduardbargues