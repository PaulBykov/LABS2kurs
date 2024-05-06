import React from 'react';

import "./style.css"

interface ISearchProps {
    setTitle: React.Dispatch<React.SetStateAction<string>>
}

function Search({setTitle}: ISearchProps) {
    const [searchText, setSearchText] = React.useState('')

    return (
        <form id="search-form" className="search-container" onSubmit={(e) => {
            e.preventDefault();
            setTitle(searchText);
        }}>
            <input type="search"
                   placeholder="Search..."
                   className="search"
                   onChange={(e) => setSearchText(e.target.value)}
            />

            <button type="submit" className="btn">
                <img src="/assets/lupa.png" alt="Search Icon" className="search-icon" />
            </button>
        </form>
    );
}

export default Search;