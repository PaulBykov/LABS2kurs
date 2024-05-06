import React from 'react';
import Button from "../../shared/button/button";

import "./style.css"
import {Link} from "react-router-dom";


export type MovieType = "any" | "movie" | "series" | "episode";

interface MovieFilterProps {
    setType: React.Dispatch<React.SetStateAction<MovieType>>;
}

function Filter(props: MovieFilterProps) {

    return (
        <div className="filter-block">
            <Link to={`/home/any`}>
                <Button text="any" onClick={() => props.setType("any")}/>
            </Link>

            <Link to={`/home/movie`}>
                <Button text="movie" onClick={() => props.setType("movie")}/>
            </Link>

            <Link to={`/home/series`}>
                <Button text="series"  onClick={() => props.setType("series")}/>
            </Link>

            <Link to={`/home/episode`}>
                <Button text="episode"  onClick={() => props.setType("episode")}/>
            </Link>
        </div>
    );
}

export default Filter;