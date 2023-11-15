# Autotexts
Решение для Directum RX 4.6
____
# Возможности решения

Отдельный справочник Автотексты с разграничением прав доступа, содержащий автотексты для использования в задачах и заданиях (разграничение реализовано с использованием записей справочника Области использования).
____
# Состав решения
 
-Модуль Автотексты.

-Справочник Автотекст (Autotext).

-Справочник Область использования (AutotextUsageArea)	

-Новая роль «Создание автотекстов». При инициализации выдаются права на создание записей и заполнение свойств справочника Автотекст и на чтение записей справочника Область использования.

-Новая роль «Использование автотекстов». При инициализации выдаются права на чтение записей справочника Автотекст и на чтение записей справочника Область использования.
____
# Локализация новых элементов разработки.

Варианты расширения функциональности на проектах

-Добавление множественного выбора областей использования для автотекстов;

-Добавление фильтрации использования автотекстов по подразделениям.
____
# Архитектурно неочевидные моменты

В рамках решения пользователю доступны все автотексты(доступ по роли). Ограничения накладываются только по области использования. Для адаптации под конкретный кейс дорабатывается функция GetAutotexts модуля Автотексты.

## Внедрение решения

При внедрении решения необходимо произвести следующие действия: 

1.Определить набор областей использования и создать в инициализации соответствующие записи справочника Область использования;

2.В перекрытиях задач/заданий добавить кнопку для добавления автотекста, которая будет вызывать серверную функцию GetAutotexts модуля автотексты, с указанием Guid области использования соответствующей задаче/заданию из которой вызывается функция.