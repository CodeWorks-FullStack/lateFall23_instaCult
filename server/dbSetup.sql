CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE cults(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(100) NOT NULL,
  coverImg VARCHAR(1000) NOT NULL,
  bio VARCHAR(1000) NOT NULL,
  leaderId  VARCHAR(255) NOT NULL,
  FOREIGN KEY (leaderId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET utf8mb4;


INSERT INTO cults
(name, coverImg, leaderId, bio)
VALUES
('Codeworks', 'https://avatars.githubusercontent.com/u/7350663?v=4', '634844a08c9d1ba02348913d', "I love coding! Becoming a Software Developer, I went from hating my daily work life to absolutely loving to get up and go to work. Now at CodeWorks I get to help others make this transition." );
-- ('Live Mas', 'https://adsreviewedtoday.files.wordpress.com/2013/05/taco_bell_live_mas_retirement_home.jpg?w=1200', '634844a08c9d1ba02348913d', "Taco Bell took to the big stage during sports' biggest weekend to host Live Más LIVE. The livestreamed, fan-centric event hit the Las Vegas strip with a years' worth of product unveils, fan recognition, musical performances and celebrity appearances. The largest and most epic announcements from the main stage included the introduction of chef collaboration program TBX, the new Cantina Chicken Menu and an unimaginable lineup of food innovations and partnerships with brands such as Cheez-It®, MTN DEW®, and Tajín®." );
-- ('Cult Of the Crocs', 'https://media.crocs.com/images/t_pdphero/f_auto%2Cq_auto/products/209392_510_ALT170/crocs', '645d75fdfdcb015333f9b0ba', 'Crocs are the best shoes hands down. People who do not think so are people who do not own a pair.');

-- CultMembers

CREATE TABLE cultMembers(
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  cultId INT NOT NULL,
  FOREIGN KEY(accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(cultId) REFERENCES cults(id) ON DELeTE CASCADE
) DEFAULT CHARSET utf8mb4;

INSERT INTO cultMembers
(accountId, cultId)
VALUES
('634844a08c9d1ba02348913d', 1);