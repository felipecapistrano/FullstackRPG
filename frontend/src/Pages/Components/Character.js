import React from "react"
import "../Styles/character.css"

function Character (props) {
    return (
        <img src={props.image} alt="oi" id="character"></img>
    )
}

export default Character