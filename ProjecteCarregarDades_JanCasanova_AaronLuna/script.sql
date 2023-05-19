DROP TABLE IF EXISTS movies;
DROP TABLE IF EXISTS actors;

CREATE TABLE IF NOT EXISTS movies (
  id INT PRIMARY KEY,
  title VARCHAR(255),
  genre VARCHAR(255),
  director VARCHAR(255),
  year INT,
  rating DECIMAL(3,1)
);

CREATE TABLE IF NOT EXISTS actors (
  movie_id INT,
  name VARCHAR(255),
  role VARCHAR(255),
  FOREIGN KEY (movie_id) REFERENCES movies(id)
);

-- Índex per a la columna "title" de la taula "movies"
CREATE INDEX idx_movies_title ON movies (title);

-- Índex per a la columna "year" de la taula "movies"
CREATE INDEX idx_movies_year ON movies (year);
