CREATE TABLE `Landmark` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` bigint(20) unsigned NOT NULL,
  `deadline` datetime DEFAULT NULL,
  `title` varchar(255) NOT NULL,
  `remark` text,
  `state` int(3) DEFAULT '0',
  `finish_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8