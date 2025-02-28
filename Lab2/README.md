# Lab 2

Задачи скопированы в [TASKS.md](./TASKS.md)

## Task 1

Функционал описывался в [Лабораторной 1](../Lab1/README.md)

Мультисервисная структура, сервисы:

* Сервис базы данных
* Веб-клиент
* Декстопный клиент
* Сервис администрирования
* Сервис рекомендаций (Возможно)

Чтобы не распыляться на всё, в течение семестра я планирую сделать

* Сервис базы данных
* Пользовательский веб-клиент 
* Декстопный клиент для администрирования

### Сервис БД

Данный сервис будет маленьким и реализует лишь доступ к базам данных через некоторое API

#### Таблица с видео данными

| video_id | user_id | description | video_data | preview_data | banned |
|----------|---------|-------------|------------|--------------|--------|
| ...      | ...     | ...         | ...        | ...          | ...    |

#### Таблица с данными пользователя

| user_id | first_name | last_name | nickname   | password_hash | banned |
|---------|------------|-----------|------------|---------------|--------|
| ...     | ...        | ...       | ...        | ...           | ...    |

#### Таблица с данными администраторов

| user_id | first_name | last_name | nickname   | password_hash |
|---------|------------|-----------|------------|---------------|
| ...     | ...        | ...       | ...        | ...           |

#### Таблица с данными репортов

| report_id | user_id | video_id | description |
|-----------|---------|----------|-------------|
| ...       | ...     | ...      | ...         |

#### Таблица с данными репортов

| report_id | user_id | video_id | description | status |
|-----------|---------|----------|-------------|--------|
| ...       | ...     | ...      | ...         | ...    |

* `user_id` --- id пользователя, который отправил репорт
* `video_id` --- id видео, на которое отправили репорт
* `status` --- статус рассмотрения репорта

#### Дополнительные структуры

DAO и DTO классы для каждой таблицы.

REST API для выполнения запросов.

### Пользовательский веб-клиент

Это веб-сайт, сервер будет на C#, сложных структур не планируется, клиент - HTML + CSS + JavaScript.

### Декстопный клиент для администрирования

Основное семестровое приложение. 

Windows приложение, в котором можно будет выполнять работу администратора.
Требуемый функционал:

* Регистрация администратора
* Проверка доступных репортов
* Вынесение вердикта по репорту (бан видео, бан пользователя и тп)
* Заведение новых администраторских репортов
* Просмотр истории модерации

#### Классы

Классы-обертки над данными из сервиса базы данных:

> AdministratorData
> - user_id
> - first_name
> - last_name
> - nickname

> UserData
> - user_id
> - first_name
> - last_name
> - nickname
> - banned

> VideoData
> - video_id
> - user_id
> - description
> - video_data
> - preview_data
> - banned

> ReportData
> - report_id
> - user_id
> - video_id
> - description
> - status

Эти классы данных большие, поэтому создаем для них классы-строители (паттерн **Строитель**)

> AdministratorDataBuilder
> - SetFirstName()
> - SetLastName()
> - SetNickname()

> ReportData
> - SetUserId()
> - SetVideoId()
> - SetDescription()
> - SetStatus()

Эти классы будут получаться через класс-стратегию (для возможности тестирования, паттерн **Стратегия**)

> AdministratorDatabaseAPIStrategy
> - GetAdministrator()
> - CreateAdministrator()
> - RemoveAdministrator()
> - EditAdministrator()

> UserDatabaseAPIStrategy
> - GetUser()
> - BanUser()

> VideoDatabaseAPIStrategy
> - GetVideo()
> - BanVideo()

> ReportDatabaseAPIStrategy
> - GetReport()
> - CreateReport()
> - EditReport()

Фасад для хранения всех стратегий базы данных (паттерн **Фасад**)

> DatabaseAPIFacade
> - GetAdministrator()
> - CreateAdministrator()
> - RemoveAdministrator()
> - EditAdministrator()
> - GetUser()
> - BanUser()
> - GetVideo()
> - BanVideo()
> - GetReport()
> - CreateReport()
> - EditReport()

Классы-команды для возможности отмены действий администратора (паттерн **Команда**):

> IAdministratorCommand
> - Execute()
> - Undo()

И менеджер команд (паттерн **Синглтон**)

> CommandManagerSingleton
> - Execute()
> - Undo()

И абстрактная фабрика для возможности создания команд(паттерн **Абстрактная фабрика**)

> IAdministratorCommandFabric
> - СreateNewReportCommand()
> - СreateBanVideoCommand()
