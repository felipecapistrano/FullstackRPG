import React, {useState} from "react"
import SideBar from "./Components/SideBar"
import SkillScript from "./Components/Scripts/SkillScript"
import TeachScript from "./Components/Scripts/TeachScript"
import "../Styles/background.css"
import "../Styles/fade.css"

function Library() {
    const [skill, setSkill] = useState(false)
    const [teach, setTeach] = useState(false)

    function includes(fun, e) {
        const scripts = [skill, teach]
        if (!scripts.includes(true))
            fun(e)
    }

    const sideButtons = [
        {name: "Criar Habilidades", script: (e) => includes(setSkill, e)},
        {name: "Ensinar Habilidades", script: (e) => includes(setTeach, e)},
        {name: "Voltar", changescene: "/Plaza", element: "dojo"}
    ]
    
    return (
        <div id="dojo" className="fadein">
            <SideBar sideButtons={sideButtons}/>
            {skill && <SkillScript end={(e) => setSkill(e)}/>}
            {teach && <TeachScript end={(e) => setTeach(e)}/>}
        </div>
    )
}

export default Library