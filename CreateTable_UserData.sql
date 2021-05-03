
CREATE TABLE `user_data` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `insert_datetime` date NOT NULL,
  `value` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4