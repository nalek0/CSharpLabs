# Lab 2

Задачи скопированы в [TASKS.md](./TASKS.md)

## Task 1

Проект в папке [Project/](../Project/).
Комментарии по коду тут:

### SRP — The Single Responsibility Principle

`AdministratorDataBuilder` и `ReportDataBuilder` реализуют единственную функцию - сборку соответствующего дата класса, реализует SRP

### OCP — The Open-Closed Principle

Интерфейсы `IAdministratorDatabaseAPIStrategy`, `IReportDatabaseAPIStrategy`, `IUserDatabaseAPIStrategy`, `IVideoDatabaseAPIStrategy`
реализуют OCP

### LSP — The Liskov Substitution Principle

Класс `CommandManagerSingleton` и метод `CommandManagerSingleton.Execute` - явное использование подкласса, использование LSP

### ISP — The Interface Segregation Principle

Интерфейсы `IAdministratorDatabaseAPIStrategy`, `IReportDatabaseAPIStrategy`, `IUserDatabaseAPIStrategy`, `IVideoDatabaseAPIStrategy`
разделяют логику взаимодействия с API базы данных, реализуют ISP

### DIP — The Dependency Inversion Principle

`DatabaseAPIFacade` иммеет инвертрорлванные зависимости, реализует DIP.
