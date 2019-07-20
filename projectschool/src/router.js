import Vue from "vue";
import Router from "vue-router";
import Alunos from "./components/Aluno/Alunos";
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
      path: "/Alunos",
      nome: "Aluno",
      component: Alunos
    },
    {
      path: "/Sobre",
      nome: "Sobre",
      component: Sobre
    }
  ]
});
