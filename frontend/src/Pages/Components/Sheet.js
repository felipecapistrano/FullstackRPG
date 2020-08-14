import React, { useState } from "react"
import {useHistory} from "react-router-dom"
import { useFormik } from "formik"
import api from "../../api"

function Sheet({data}) {
    const history = useHistory()
    const [skillsTab, setSkillsTab] = useState(false)

    const Id = Number(localStorage.getItem("Id"))

    const learnedSkills = []
    data.habilidadesPersonagem.map((e) => {if(e.PersonagemId === Id) learnedSkills.push(e.HabilidadeId)})
    const skills = data.habilidades.filter(e => learnedSkills.includes(e.Id))

    const characters = data.personagens.filter(e => e.Id !== Id)

    const formik = useFormik({
        initialValues: {
            Id: data.currentCharacter.Id,
            Nome: data.currentCharacter.Nome,
            RaçaId: data.currentCharacter.RaçaId,
            ArmaId: data.currentCharacter.ArmaId,
            CapaceteId: data.currentCharacter.CapaceteId,
            ArmaduraId: data.currentCharacter.ArmaduraId,
            PersonagemPaiId: data.currentCharacter.PersonagemPaiId
        },
        onSubmit: values => {
            try{
                api.post("https://localhost:44386/api/personagens/salvar", values)
                history.go()
            }catch (err) {
                return
            }
        }})

        function createOptions(list) {
            return list.map((e) => {
                if(e !== undefined) return <option value={e.Id} key={e.Id}>{e.Nome}</option>
            })
        }

        function createP(list) {
            return list.map((e) => {
                return (
                    <p className="tooltip" id="skills">{e.Nome}
                        <span className="tooltiptext">{e.Descricao}</span>
                    </p>
                )
            })
        }

        if (!data) return null

        return (
            <form className="form" id="sheet" onSubmit={formik.handleSubmit}>
            {(!skillsTab && <>
                <label htmlFor="Nome">Nome</label>
                <input name="Nome" onChange={formik.handleChange} value={formik.values.Nome}></input>

                <label htmlFor="PersonagemPaiId">Pai</label>
                <select name="PersonagemPaiId" onChange={formik.handleChange} value={formik.values.PersonagemPaiId}>
                    <option value="">-</option>
                    {createOptions(characters)}
                </select>

                <label htmlFor="RaçaId">Raça</label>
                <select name="RaçaId" onChange={formik.handleChange} value={formik.values.RaçaId}>
                    <option value="">-</option>
                    {createOptions(data.raças)}
                </select>
                
                <label htmlFor="ArmaId">Arma</label>
                <select name="ArmaId" id="ArmaId" onChange={formik.handleChange} value={formik.values.ArmaId}>
                    <option value="">-</option>
                    {createOptions(data.armas)}
                </select>

                <label htmlFor="CapaceteId">Capacete</label>
                <select name="CapaceteId" id="CapaceteId" onChange={formik.handleChange} value={formik.values.CapaceteId}>
                    <option value="">-</option>
                    {createOptions(data.capacetes)}
                </select>

                <label htmlFor="ArmaduraId">Armadura</label>
                <select name="ArmaduraId" id="ArmaduraId" onChange={formik.handleChange} value={formik.values.ArmaduraId}>
                    <option value="">-</option>
                    {createOptions(data.armaduras)}
                </select>
                </>) || createP(skills)}
                <div id="button-container">
                    <button className="sheet-button" type="submit">Editar</button>
                    <button onClick={() => setSkillsTab(!skillsTab)} className="sheet-button" type="button" >{skillsTab? "Informações": "Habilidades"}</button>
                </div>
            </form>
        )
}

export default Sheet