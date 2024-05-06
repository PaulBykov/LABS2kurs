import React from 'react';

import "./style.css"
import {Link} from "react-router-dom";
export interface IMovie {
    Title: string;
    Year: string;
    imdbID: string;
    Type: string;
    Poster: string;
}


function MovieCard(Movie: IMovie) {
    return (
        <div className="MovieCard">
            <div className="MovieCardPoster">
                <Link to={`/movie/${Movie.imdbID}`}>
                    <img src={Movie.Poster} alt="Poster"/>
                </Link>
            </div>

            <div className="MovieCardTitle">
                {Movie.Title}
            </div>

            <div className="MovieCardDetails">
                <span>{Movie.Year}</span>
                <span className="movie-type">{Movie.Type}</span>
            </div>
        </div>
    );
}

export default MovieCard;