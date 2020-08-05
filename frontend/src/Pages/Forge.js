import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import "./Styles/background.css"
import "./Styles/fade.css"

function Forge() {
    const [startText, setStartText] = useState(false)

    const sideButtons = [
        {name: "Forjar", script: (e) => setStartText(e)},
        {name: "Entregar material", script: (e) => setStartText(e)},
        {name: "Voltar", changescene: "/Plaza", element: "forge"}
    ]
    
    return (
        <div id="forge" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {/*startText && <GuildScript end={(e) => setStartText(e)}/>*/}
        </div>
    )
}

export default Forge