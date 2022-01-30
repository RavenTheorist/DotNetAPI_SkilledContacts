# DotNetAPI_SkilledContacts
A WepAPI made in .NET Core showcasing some of the possibilities, while handling a list of Contacts linked to a list of Skills

N.B.:
- The project contains a custom logger CustomMessageLogger.cs to catch exceptions and warning.
- Security was implemented, but commented/disabled for an easier use. CORS and JWT were implemented.
- Migrations were generated, this project uses a code first approach in terms of Database.
- Database server can be configured in the appsettings.json
- The CRUD methods for the Skills are defined in the DefaultSkillRepository.cs and called from the SkillsController using a mediator
- Some design patterns and principles were implemented in order to make the API more reliable, extensible and less prone to errors:
   - Hexagonal Architecture: Domain, Infrastructure and the API
   - Dependency Injections, following Microsoft Manual's advises and examples
   - Unity of Work
   - Repository
   - Mediator

Purpose:
Create the "Contacts API". It's a simple API, where a user can get a quick overview over all contacts resources like persons, skills...

The following use cases should be implemented:
 
UC1
Create an CRUD endpoint for managing contacts. A contact should have at least the following attributes and appropriate validation:
- Firstname
- Lastname
- Fullname
- Address
- Email
- Mobile phone number

UC2
Create a CRUD endpoint for skills. A contact can have multiple skills and a skill can belong to multiple contacts. A skill should have the following attributes and appropriate validation:
- Name
- Level (expertise)

UC3
Document your API with Swagger.

UC4 (optional)
Implement the following security aspects. All bullet points are optional and can be implemented partially.
- Authentication
- Authorization
    - Users can only change their contact
    - Have checks for skills changes (e.g. the current user can’t change skills for other users)