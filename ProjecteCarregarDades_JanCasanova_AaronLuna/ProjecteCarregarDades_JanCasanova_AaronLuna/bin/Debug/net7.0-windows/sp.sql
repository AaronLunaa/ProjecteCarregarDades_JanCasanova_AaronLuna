-- Elimina el procediment emmagatzemat si existeix
DROP PROCEDURE IF EXISTS GetMovieWithHighestRating;

-- Crea el procediment emmagatzemat
DELIMITER //

CREATE PROCEDURE GetMovieWithHighestRating()
BEGIN
    -- Variable per emmagatzemar el rating més alt
    DECLARE highestRating DECIMAL(3,1);
    
    -- Obté el rating més alt de la taula de pel·lícules
    SELECT MAX(rating) INTO highestRating FROM movies;
    
    -- Crea un fitxer XML amb la pel·lícula amb el rating més alt
    SELECT 
        m.id AS '@id',
        m.title AS 'title',
        m.genre AS 'genre',
        m.director AS 'director',
        m.year AS 'year',
        m.rating AS 'rating',
        (SELECT 
            a.name AS '@name',
            a.role AS '@role'
         FROM actors a
         WHERE a.movie_id = m.id
         FOR XML PATH('actor'), TYPE)
    FROM movies m
    WHERE m.rating = highestRating
    FOR XML PATH('movie'), ROOT('catalog'), TYPE
    INTO 'highest_rated_movie.xml';
END //

DELIMITER ;
