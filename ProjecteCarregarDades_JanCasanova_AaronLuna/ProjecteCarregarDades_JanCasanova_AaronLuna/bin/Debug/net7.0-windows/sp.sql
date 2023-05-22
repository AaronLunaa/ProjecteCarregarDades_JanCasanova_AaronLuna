-- Elimina el procediment emmagatzemat si existeix
DROP PROCEDURE IF EXISTS GetMovieWithHighestRating;

-- Crea el procediment emmagatzemat
CREATE PROCEDURE GetMovieWithHighestRating()
BEGIN
    -- Variable per emmagatzemar la puntuació màxima
    DECLARE highestRating DECIMAL(3,1);
    DECLARE xmlContent TEXT; -- Afegit: Definició del paràmetre '@xml'

    -- Obté la puntuació màxima de la taula de pel·lícules
    SELECT MAX(rating) INTO highestRating FROM movies;

    -- Crea un fitxer XML amb la pel·lícula amb la puntuació més alta
    SET xmlContent = CONCAT('<?xml version="1.0" encoding="UTF-8"?><catalog>',
        (SELECT 
            CONCAT('<movie id="', m.id, '">',
                '<title>', m.title, '</title>',
                '<genre>', m.genre, '</genre>',
                '<director>', m.director, '</director>',
                '<year>', m.year, '</year>',
                '<rating>', m.rating, '</rating>',
                '<actors>',
                (SELECT 
                    GROUP_CONCAT(CONCAT('<actor name="', a.name, '" role="', a.role, '")' SEPARATOR ',')
                 FROM actors a
                 WHERE a.movie_id = m.id),
                '</actors>',
                '</movie>')
        FROM movies m
        WHERE m.rating = highestRating)
        ,'</catalog>');

    -- Escriu el contingut XML al fitxer
    SELECT xmlContent INTO OUTFILE 'highest_rated_movie.xml';
END;






