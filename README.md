# Relational_Database_Relationship_Types
 Defining relationship types between data in relational databases
 
- It is designed as a resource for understanding and implementing Entity Framework Core's different relationship types. Our content covers "One-to-One", "One-to-Many" and "Many-to-Many" relationship types and explains step by step how to model these relationships, reflect them in the database, and use them in your application code.

## Content Headings:

* <b>Default Rule:</b> A detailed explanation of the advantages and limitations of using default rules to define relationship types.

* <b>Usage of Data Annotation:</b> It shows with examples how to use Data Annotation to define our data model in relation. This method offers an easy-to-understand and fast way.

* <b>Fluent API Usage:</b> Shows step by step how to determine relationship types using Fluent API. This approach provides greater flexibility and supports advanced scenarios.

This repository is a guide for developers using Entity Framework Core. It contains all the information necessary to understand and apply relationship types correctly.

<b> ONE TO MANY  </b>

![screenshot 1](https://github.com/sercan96/Relational_Database_Relationship_Types/assets/38535473/56cb53da-6c1b-4745-8840-3efef1edaf30)

* In a relationship, the "dependent" party is the party that is dependent on the other party in the relationship. In a "one-to-many" relationship, the "many" party is usually dependent.

* Employee class depends on Department class. That is, Employee objects depend on Department objects. When a new department is created or we add a new employee to an existing department, Employee objects adapt to these changes. For example, a new employee's DepartmentId property is assigned to the corresponding department's Id, and that employee is added to the Employees collection. In this way, the state of the dependent class is shaped according to the state of the parent class that depends on it, ensuring data integrity and harmony between related data.

![OneToMany](https://github.com/sercan96/Relational_Database_Relationship_Types/assets/38535473/d6c82383-de87-4f80-9bc9-6de2c9118e5c) 

* When adding newly added Employee objects to an existing department, the Id value of this department must be assigned to the DepartmentId property of the Employee object. Thanks to this Id, information about the relevant DepartmentId will be sent to the Department object of the employee object.
  
* That is, when new Employee objects are added to the Department object, Entity Framework automatically associates the DepartmentId property of each Employee object with the Id value of the relevant Department object and adds new records to the Employee table by reflecting this relationship in the database. In this way, related data is stored consistently in the database.
 
* When ids are associated, the object corresponding to the id is also filled.
  



