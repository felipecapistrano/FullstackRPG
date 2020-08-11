import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character3.png"
import Form from "../Form"
import useDataFetch from "../useDataFetch"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function WeaponScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const data = {
        tipos: useDataFetch("/api/tipoarmas/listar"),
    }

    const config = {
        initialValues: {
            Nome: "",
            TipoId:""
        },
        url: "/api/armas/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [{
            id: "Nome",
            titulo: "Nome"
        }],
        select: [{
            id: "Tipoid",
            titulo: "Tipoid",
            options: data.tipos
        }],
    }

    const text = [
        "Uma arma? Ok.",
        "Me diga que tipo de arma você quer.",
        "",
        "Hmmmm...",
        "Uma das melhores que já fiz!"
    ]

    function script () {
        if (currentText === 1) {
            setForm(true)
            setCurrentText(currentText + 1)
        }
        else if (currentText === 2)
            return
        else if(!text[currentText + 1])
            props.end(false)
        else
            setCurrentText(currentText + 1)
    }

    return (
        <div className="fadein">
            <img src={character} alt="oi" id="character"></img>
            <DialogueBox click={() => script()} text={text[currentText]}/>
            {form && data.tipos && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default WeaponScript