const API_KEY = process.env.REACT_APP_API_KEY;

export interface IMovieData {
    Title: string;
    Year: string;
    Type: string;
    Poster: string;
    Rated: string;
    Runtime: string;
    Genre: string;
    Director: string;
    Writer: string;
    Actors: string;
    Plot: string;
    Language: string;
    Country: string;
    Ratings: { Source: string; Value: string }[];
    Metascore: string;
    imdbRating: string;
    imdbVotes: string;
    imdbID: string;
}


export async function getMovie(id: string) {
    return await fetch(`https://www.omdbapi.com/?apikey=${API_KEY}&i=${id}`)
        .then(response => response.json())
        .then((result: IMovieData) => result);
}

