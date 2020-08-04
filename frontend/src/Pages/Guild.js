import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import GuildScript from "./Components/Scripts/GuildScript"
import "./Styles/background.css"
import "./Styles/fade.css"

function Guild() {
    const [startText, setStartText] = useState(false)

    const sideButtons = [
        {name: "Cadastrar-se", script: (e) => setStartText(e)},
        {name: "Identificar-se", script: (e) => setStartText(e)},
        {name: "Voltar", changescene: "/Plaza", element: "guild"}
    ]
    
    return (
        <div id="guild" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {startText && <GuildScript end={(e) => setStartText(e)}/>}
        </div>
    )
}

export default Guild