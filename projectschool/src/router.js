import Vue from "vue";
import Router from "vue-router";
import Alunos from "./components/Aluno/Alunos";
import AlunoDetalhe from "./components/Aluno/AlunosDetalhe";
import Professor from "./components/Professor/Professor";
import Sobre from "./components/Sobre/Sobre";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/Professor",
      nome: "Professor",
      component: Professor
    },
    {
      path: "/Alunos/:prof_id",
      nome: "Aluno",
      component: Alunos
    },
    {
      path: "/TodosAlunos",
      nome: "Aluno",
      component: Alunos
    },
    {
      path: "/AlunoDetalhe/:id",
      nome: "Aluno",
      component: AlunoDetalhe
    },
    {
      path: "/Sobre",
      nome: "Sobre",
      component: Sobre
    }
  ]
});
