import React from 'react';
import MovieCard, {IMovie} from "../MovieCard/MovieCard";

import "./style.css"

interface IMovieListProps {
    movies: IMovie[]
}

function MovieList({movies}: IMovieListProps) {
    if(movies === undefined || movies.length === 0) {
        return (<div className="not-found">No such movies found!</div>)
    }

    return (
        <div className="movies">
            {movies.map((movie) => (
                <MovieCard key={movie.imdbID} Title={movie.Title} Year={movie.Year} imdbID={movie.imdbID} Type={movie.Type} Poster={movie.Poster}/>))
            }
        </div>
    );
}

export default MovieList;