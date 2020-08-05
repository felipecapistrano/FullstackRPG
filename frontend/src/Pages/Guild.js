import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import RegisterScript from "./Components/Scripts/RegisterScript"
import "./Styles/background.css"
import "./Styles/fade.css"

function Guild() {
    const [register, setRegister] = useState(false)
    const [identify, setIdentify] = useState(false)

    const sideButtons = [
        {name: "Cadastrar-se", script: (e) => setRegister(e)},
        {name: "Identificar-se", script: (e) => setIdentify(e)},
        {name: "Voltar", changescene: "/Plaza", element: "guild"}
    ]
    
    return (
        <div id="guild" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {register && <RegisterScript end={(e) => setRegister(e)}/>}
        </div>
    )
}

export default Guild