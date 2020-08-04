import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import GuildText from "./Texts/GuildText"
import Character from "../Character"
import character from "../../../Assets/character1.png"
import "../../Styles/script.css"
import "../../Styles/fade.css"

function GuildScript (props) {
    const [currentText, setCurrentText] = useState(0)

    function script () {
        if(!GuildText[currentText + 1]){
            props.end(false)
        }
        else
            setCurrentText(currentText + 1)
    }
    return (
        <div className="fadein">
            <Character image={character}/>
            <DialogueBox click={() => script()} text={GuildText[currentText]}/>
        </div>
    )
}

export default GuildScript