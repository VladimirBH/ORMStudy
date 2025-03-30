-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               9.0.1 - MySQL Community Server - GPL
-- Операционная система:         Linux
-- HeidiSQL Версия:              12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных DBProject
CREATE DATABASE IF NOT EXISTS `DBProject` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `DBProject`;

-- Дамп структуры для таблица DBProject.Mentor
CREATE TABLE IF NOT EXISTS `Mentor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `lastName` varchar(25) NOT NULL,
  `name` varchar(25) NOT NULL,
  `gender` varchar(2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.Mentor: ~0 rows (приблизительно)
INSERT INTO `Mentor` (`id`, `lastName`, `name`, `gender`) VALUES
	(1, 'Иванов', 'Иван', 'М'),
	(2, 'Петров', 'Петр', 'М'),
	(3, 'Сидорова', 'Анна', 'Ж'),
	(4, 'Кузнецов', 'Алексей', 'М'),
	(5, 'Морозова', 'Елена', 'Ж');

-- Дамп структуры для таблица DBProject.Project
CREATE TABLE IF NOT EXISTS `Project` (
  `shifr` int NOT NULL AUTO_INCREMENT,
  `project` varchar(50) NOT NULL,
  `topic` varchar(25) NOT NULL,
  `duration` int NOT NULL,
  `dateStart` date NOT NULL,
  PRIMARY KEY (`shifr`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.Project: ~0 rows (приблизительно)
INSERT INTO `Project` (`shifr`, `project`, `topic`, `duration`, `dateStart`) VALUES
	(1, 'Проект Альфа', 'Разработка ПО', 12, '2023-01-15'),
	(2, 'Проект Бета', 'Исследование рынка', 6, '2023-02-01'),
	(3, 'Проект Гамма', 'Маркетинговая стратегия', 9, '2023-03-10'),
	(4, 'Проект Дельта', 'Автоматизация процессов', 18, '2023-04-20'),
	(5, 'Проект Эпсилон', 'Аналитика данных', 12, '2023-05-05');

-- Дамп структуры для таблица DBProject.Students
CREATE TABLE IF NOT EXISTS `Students` (
  `id` int NOT NULL AUTO_INCREMENT,
  `lastName` varchar(25) NOT NULL,
  `name` varchar(25) NOT NULL,
  `gender` varchar(2) NOT NULL,
  `team` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Students_team` (`team`),
  CONSTRAINT `FK_Students_Team_team` FOREIGN KEY (`team`) REFERENCES `Team` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.Students: ~0 rows (приблизительно)
INSERT INTO `Students` (`id`, `lastName`, `name`, `gender`, `team`) VALUES
	(1, 'Смирнов', 'Александр', 'М', 1),
	(2, 'Ковалев', 'Дмитрий', 'М', 1),
	(3, 'Федорова', 'Мария', 'Ж', 2),
	(4, 'Николаев', 'Сергей', 'М', 2),
	(5, 'Зайцева', 'Ольга', 'Ж', 3),
	(6, 'Михайлов', 'Андрей', 'М', 3),
	(7, 'Васильева', 'Екатерина', 'Ж', 4),
	(8, 'Попов', 'Игорь', 'М', 4),
	(9, 'Лебедев', 'Владимир', 'М', 5);

-- Дамп структуры для таблица DBProject.Team
CREATE TABLE IF NOT EXISTS `Team` (
  `id` int NOT NULL AUTO_INCREMENT,
  `team` varchar(50) NOT NULL,
  `mentor` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Team_mentor` (`mentor`),
  CONSTRAINT `FK_Team_Mentor_mentor` FOREIGN KEY (`mentor`) REFERENCES `Mentor` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.Team: ~0 rows (приблизительно)
INSERT INTO `Team` (`id`, `team`, `mentor`) VALUES
	(1, 'Команда 1', 1),
	(2, 'Команда 2', 2),
	(3, 'Команда 3', 3),
	(4, 'Команда 4', 4),
	(5, 'Команда 5', 5);

-- Дамп структуры для таблица DBProject.Work
CREATE TABLE IF NOT EXISTS `Work` (
  `id` int NOT NULL AUTO_INCREMENT,
  `takt` int NOT NULL,
  `result` varchar(100) NOT NULL,
  `student_id` int NOT NULL,
  `project_shifr` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Work_project_shifr` (`project_shifr`),
  KEY `IX_Work_student_id` (`student_id`),
  CONSTRAINT `FK_Work_Project_project_shifr` FOREIGN KEY (`project_shifr`) REFERENCES `Project` (`shifr`) ON DELETE CASCADE,
  CONSTRAINT `FK_Work_Students_student_id` FOREIGN KEY (`student_id`) REFERENCES `Students` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.Work: ~0 rows (приблизительно)
INSERT INTO `Work` (`id`, `takt`, `result`, `student_id`, `project_shifr`) VALUES
	(1, 1, 'Анализ требований завершен', 1, 1),
	(2, 2, 'Разработка прототипа начата', 2, 1),
	(3, 3, 'Тестирование модуля проведено', 3, 2),
	(4, 4, 'Отчет по исследованию готов', 4, 2),
	(5, 5, 'Презентация проекта создана', 5, 3),
	(6, 6, 'Документация обновлена', 6, 3),
	(7, 7, 'Алгоритм оптимизирован', 7, 4),
	(8, 8, 'Баг исправлен', 8, 4),
	(9, 9, 'Дашборд разработан', 9, 5);

-- Дамп структуры для таблица DBProject.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы DBProject.__EFMigrationsHistory: ~1 rows (приблизительно)
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250330210754_ProjectMigration', '8.0.0'),
	('20250330223413_UpdateForeignKeys', '8.0.0');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
