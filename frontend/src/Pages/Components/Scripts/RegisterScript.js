import React, {useState} from "react"
import DialogueBox from "../DialogueBox"
import character from "../../../Assets/character1.png"
import Form from "../Form"
import useDataFetch from "../useDataFetch"
import "../../../Styles/fade.css"
import "../../../Styles/character.css"

function RegisterScript (props) {
    const [currentText, setCurrentText] = useState(0)
    const [form, setForm] = useState(false)

    const data = {
        raças: useDataFetch("/api/raças/listar"),
        armas: useDataFetch("/api/armas/listar"),
        capacetes: useDataFetch("/api/capacetes/listar"),
        armaduras: useDataFetch("/api/armaduras/listar"),
        pai: useDataFetch("/api/personagens/listar")
    }

    const config = {
        initialValues: {
            Nome: "",
            RaçaId: "",
            ArmaId: "",
            CapaceteId: "",
            ArmaduraId: "",
        },
        url: "/api/personagens/salvar",
        finish: (e) => {
            setCurrentText(currentText + 1)
            setForm(e)
        },
        input: [{
            id: "Nome",
            titulo: "Nome"
        }],
        select: [{
            id: "RaçaId",
            titulo: "Raça",
            options: data.raças
        },
        {
            id: "ArmaId",
            titulo: "Arma",
            options: data.armas
        },
        {
            id: "CapaceteId",
            titulo: "Capacete",
            options: data.capacetes
        },
        {
            id: "ArmaduraId",
            titulo: "Armadura",
            options: data.armaduras
        },
        {
            id: "PersonagemPaiId",
            titulo: "Pai",
            options: data.pai
        }
    ]
    }

    const text = [
        "Olá! Seja bem-vindo(a)",
        "Já que é novo por aqui vou precisar que faça o seu cadastro.",
        "Não se preocupe, só preciso de alguns dados.",
        "",
        "Muito obrigada!"
    ]

    function script () {
        if (localStorage.getItem("Id"))
            props.end(false)
        else if (currentText === 2) {
            setForm(true)
            setCurrentText(currentText + 1)
        }
        else if (currentText === 3)
            return
        else if(!text[currentText + 1])
            props.end(false)
        else
            setCurrentText(currentText + 1)
    }
    if (localStorage.getItem("Id")) text[currentText] = "Você já está cadastrado."
    return (
        <div className="fadein">
            <img src={character} alt="oi" id="character"></img>
            <DialogueBox click={() => script()} text={text[currentText]}/>
            {form && data.raças && data.armas && data.capacetes && data.armaduras && 
                <Form
                config={config}
                />
            }
        </div>
    )
}

export default RegisterScript