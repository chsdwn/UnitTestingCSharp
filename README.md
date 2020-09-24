#### VSCode Code coverage extensions and packages
- Packages: coverlet.collector, coverlet.msbuild
- Extensions: .NET Core Test Explorer, Coverage Gutters

#### To create lcov.info file run this command.
- dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info