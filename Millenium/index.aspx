<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Millenium.WebForm1" %>

<!DOCTYPE html5>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <title>CRUD</title>
</head>
<body>
    <div class="m-2">
        <div class="row">
                <div class="col-3">
                   <form id="cadForm" runat="server">
                        <a class="btn btn-success btn-block" data-toggle="collapse" href="#cadastroContainer" role="button" aria-expanded="false" aria-controls="cadastroContainer">Inserir</a>
                        
                        <div class="collapse p-3 border" id="cadastroContainer">
                            
                                <div class="container">
                                    <div class="row">
                                        <div class="col-12">
                                            <label>Nome:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertNome" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>                                    
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Email:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertEmail" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Logradouro:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertLogradouro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Numero:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertNumero" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-12">
                                            <label>Comp:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertComp" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Bairro:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertBairro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Cidade:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertCidade" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                         <div class="col-12">
                                            <label>CEP:</label>
                                            <asp:TextBox CssClass="form-control" ID="InsertCEP" runat="server" MaxLength="7"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                         <asp:Label class="col-12" ID="AlertInsert" runat="server"></asp:Label>   
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Button CssClass="btn btn-primary btn-block mt-3" runat="server" text="Cadastrar" ID="btnCad" OnClick="btnCad_Click"/>
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                        
                        <a class="btn btn-info btn-block" data-toggle="collapse" href="#Consulta" role="button" aria-expanded="false" aria-controls="Consulta">Consultar</a>
                        <div id="Consulta" class="collapse border p-3">
                            <div class="container">
                                
                                <div class="row">
                                    <div class="col-12">
                                        <label>Id inicial:</label>
                                        <asp:TextBox CssClass="form-control" ID="ConsultIdInicial" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <label>Id final:</label>
                                        <asp:TextBox CssClass="form-control" ID="ConsultIdFinal" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <asp:Label class="col-12" ID="ConsultAlert" runat="server"></asp:Label>   
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <asp:Button CssClass="btn btn-primary btn-block mt-3" runat="server" text="Consulta" ID="btnConsulta" OnClick="btnConsulta_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <a class="btn btn-danger btn-block" data-toggle="collapse" href="#Deletar" role="button" aria-expanded="false" aria-controls="Deletar">Deletar</a>
                        <div id="Deletar" class="collapse border p-3">
                            <div class="container">
                                
                                <div class="row">
                                    <div class="col-12">
                                        <label>Id:</label>
                                        <asp:TextBox CssClass="form-control" ID="DelId" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                     <asp:Label class="col-12" ID="DelAlert" runat="server"></asp:Label>   
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <asp:Button CssClass="btn btn-primary btn-block mt-3" runat="server" text="Excluir" ID="btnExcluir" OnClick="btnExcluir_Click"/>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <a class="btn btn-warning btn-block"  data-toggle="collapse" href="#Atualizar" role="button" aria-expanded="false" aria-controls="Atualizar">Atualizar</a>
                        <div id="Atualizar" class="collapse border p-3">
                                    
                                    <div class="row">
                                        <div class="col-12">
                                            <label>Id:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttId" runat="server" ></asp:TextBox>                                    
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Nome:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttNome" runat="server"></asp:TextBox>                                    
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Email:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttEmail" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Logradouro:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttLogradouro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Numero:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttNumero" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-12">
                                            <label>Complemento:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttComp" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Bairro:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttBairro" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Cidade:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttCidade" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                         <div class="col-12">
                                            <label>CEP:</label>
                                            <asp:TextBox CssClass="form-control" ID="AttCEP" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Label class="col-12" ID="AttAlert" runat="server"></asp:Label>  
                                    </div>
                            <div class="row">
                                <div class="col-12">
                                    <asp:Button CssClass="btn btn-primary btn-block mt-3" runat="server" text="Atualizar" ID="btnAtualizar" OnClick="btnAtualizar_Click"/>
                                </div>
                            </div>

                        </div>
                    </form>
                    </div>
            
                    <div class="col-9">
                        <div class="row">
                            <div class="container">
                                <asp:Table CssClass="table table-hover text-center" runat="server" ID="funcionarios">
                                    <asp:TableHeaderRow CssClass="thead-dark">
                                        <asp:TableHeaderCell>Id</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Nome</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Logradouro</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Numero</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Comp</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Bairro</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>CEP</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cidade</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div> 
                    </div>
                </div>
           </div>
        <div>       
   </div>
    

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
 
    </body>
</html>
