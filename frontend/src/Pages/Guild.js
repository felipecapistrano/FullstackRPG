import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import RegisterScript from "./Components/Scripts/RegisterScript"
import IdentifyScript from "./Components/Scripts/IdentifyScript"
import "../Styles/background.css"
import "../Styles/fade.css"

function Guild() {
    const [register, setRegister] = useState(false)
    const [identify, setIdentify] = useState(false)

    function includes(fun, e) {
        const scripts = [register, identify]
        if (!scripts.includes(true))
            fun(e)
    }

    const sideButtons = [
        {name: "Cadastrar-se", script: (e) => includes(setRegister, e)},
        {name: "Identificar-se", script: (e) => includes(setIdentify, e)},
        {name: "Voltar", changescene: "/Plaza", element: "guild"}
    ]
    
    return (
        <div id="guild" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {register && <RegisterScript end={(e) => setRegister(e)}/>}
            {identify && <IdentifyScript end={(e) => setIdentify(e)}/>}
        </div>
    )
}

export default Guild