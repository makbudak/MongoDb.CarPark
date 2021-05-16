<template>    
    <div class="row">
        <div class="col-12">
            <h3>Markalar</h3>
            <DxDataGrid :data-source="brands"
                        :show-borders="true">
                <DxColumn :width="100"
                          :allow-sorting="false"                          
                          cell-template="cellTemplate" />
                <DxColumn data-field="name" caption="Adý" />
                <DxPaging :page-size="10" />
                <template #cellTemplate="{ data }">
                    <DxButton @click="edit(data)">Düzenle</DxButton>
                </template>
            </DxDataGrid>
        </div>
    </div>
</template>


<script>
    import axios from 'axios';
    import {        
        DxDataGrid,
        DxColumn,
        DxPaging,
    } from 'devextreme-vue/data-grid';
    import DxButton from 'devextreme-vue/button';

    export default {
        name: "FetchData",
        components: {
            DxDataGrid,
            DxColumn,
            DxPaging,
            DxButton
        },
        data() {
            return {
                brands: []
            }
        },
        methods: {
            edit(e) {
                console.log(e.data.name);
            },
            getBrands() {
                axios.get('/api/Brand')
                    .then((response) => {
                        this.brands = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getBrands();
        }
    };
</script>