import {IMovie} from "../../MovieCard/MovieCard";
import PRODUCTS from "./state"

export async function getMovies(title: string): Promise<IMovie[]> {
    
    if(title == ""){
        return PRODUCTS;
    }

    return PRODUCTS.filter((movie) => movie.Title.toLowerCase().match(title.toLowerCase()));
}
