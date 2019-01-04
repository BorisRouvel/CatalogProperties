using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using KD.SDK;

namespace KD
{
    namespace CatalogProperties
    {
        public class Reference : System.ComponentModel.Component
        {
            public KD.SDKComponent.AppliComponent CurrentAppli { get; private set; }

            private string _catalogfilename;
            public List<int> _handleTypeNumberToDispatchTableList = new List<int>();
            public static List<int> _modelsFinishesTypesGetModelFinishFirstLine = new List<int>();
            public static List<int> _modelsFinishesTypesGetModelHandleFirstLine = new List<int>();

            public Reference()
            {
            }
            public Reference(KD.SDKComponent.AppliComponent appli)
            {
                this.CurrentAppli = appli;
            }
            public Reference(KD.SDKComponent.AppliComponent appli, string catalogfilename)
            {
                this.CurrentAppli = appli;
                this._catalogfilename = catalogfilename;
                this.CurrentAppli.Catalog.FileLoad(catalogfilename, Xlink);
            }
            public Reference(KD.SDKComponent.AppliComponent appli, int blocklineindex, int articlelineindex)
            {
                this.CurrentAppli = appli;
                this.BlockLineIndex = blocklineindex;
                this.ArticleLineIndex = articlelineindex;
                this.SectionLineIndex = appli.Catalog.TableGetClusterRankFromLineRank(CatalogEnum.TableId.BLOCKS, blocklineindex);

                //Reference._modelsFinishesTypesGetModelFinishFirstLine = ModelsFinishesTypes_GetModelFinishFirstLine;
                //Reference._modelsFinishesTypesGetModelHandleFirstLine = ModelsFinishesTypes_GetModelHandleFirstLine;
            }
            //For do with section and (-1)
            //public Reference(KD.SDKComponent.AppliComponent appli, int sectionlineindex, int blocklineindex, int articlelineindex)
            //{
            //    this.CurrentAppli = appli;
            //    this.SectionLineIndex = sectionlineindex;
            //    this.BlockLineIndex = blocklineindex;
            //    this.ArticleLineIndex = articlelineindex;                
            //}

            #region // Properties

            #region // Indexation
            public int BlockLineIndex { get; private set; }
            public int ArticleLineIndex { get; private set; }
            public int SectionLineIndex { get; private set; }
            #endregion

            #region // Catalog Information
            public int IsKDorKDStoConvertToInt(object param)
            {
                return (int)param;
            }

            public string CatalogFileName
            {
                get
                {
                    return _catalogfilename; // this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.FILENAME);
                }
                set
                {
                    _catalogfilename = value;
                }
            }
            public string CatalogName
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.NAME);
                }
            }
            public string XlinkCode
            {
                get
                {
                    string openCatalogFileName = CatalogFileName;
                    if (!CatalogFileName.Contains(Const.catalogExtension)) { openCatalogFileName += Const.catalogExtension; }
                    return this.CurrentAppli.AppliCatSetXLink(openCatalogFileName, 0, String.Empty, Const.catalogsDir);

                }
            }
            public string Xlink
            {
                get
                {
                    Byte[] data = System.Convert.FromBase64String(XlinkCode);
                    return System.Text.ASCIIEncoding.ASCII.GetString(data);
                }
            }
            public string BaseCatalog
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.BASECATALOG);
                }
            }
            public string BaseCatalogDate
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.BASECATALOGDATE);
                }
            }
            public string BaseCatalogTime
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.BASECATALOGTIME);
                }
            }
            public string CatalogCode
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.CODE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.CODE);
                }
            }
            public string CatalogHotlineCode
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.ASSCODE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.ASSCODE);
                }
            }
            public bool IsComplementaryCatalog()
            {
                if (this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.ISCOMPLEMENTARYCATALOG) == KD.StringTools.Const.One)
                {
                    return true;
                }
                return false;
            }
            public string CatalogCreationDate
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.CREATIONDATE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.CREATIONDATE);
                }
            }
            public string CatalogModifyDate
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.MODIFICATIONDATE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.MODIFICATIONDATE);
                }
            }
            public string CatalogCurrency
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.CURRENCY);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.CURRENCY);
                }
            }
            public string CatalogType
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.TYPE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.TYPE);
                }
            }
            public string CatalogSubType
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.SUBTYPE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.SUBTYPE);
                }
            }
            public string CatalogLanguage
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.LANGUAGE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.LANGUAGE);
                }
            }
            public string CatalogUnit
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.UNIT);
                }
            }
            public string CatalogStartValidateOn
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.STARTVALIDITYDATE_ON);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.STARTVALIDITYDATE_ON);
                }
            }
            public string CatalogStartValidate
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.STARTVALIDITYDATE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.STARTVALIDITYDATE);
                }
            }
            public string CatalogEndValidateOn
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.ENDVALIDITYDATE_ON);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.ENDVALIDITYDATE_ON);
                }
            }
            public string CatalogEndValidate
            {
                get
                {
                    return this.CurrentAppli.Catalog.GetInfo(CatalogEnum.InfoId.ENDVALIDITYDATE);
                }
                set
                {
                    this.CurrentAppli.Catalog.SetInfo(value, (int)CatalogEnum.InfoId.ENDVALIDITYDATE);
                }
            }

            #endregion

            #region //Number lines information
            public int ConstanteLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.CONSTANTS, Const.indexBase);
                }

            }
            public int SectionLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.SECTIONS, Const.indexBase);
                }

            }
            public int BlockLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.BLOCKS, Const.indexBase);
                }

            }
            public int ReferenceLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.ARTICLES, Const.indexBase);
                }

            }
            public int ModelLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.MODELS, Const.indexBase);
                }

            }
            public int ModelFinishTypesLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.MODELFINISHTYPES, Const.indexBase);
                }

            }
            public int ModelFinishesLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.MODELFINISHES, Const.indexBase);
                }

            }
            public int ModelHandlesLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.MODELHANDLES, Const.indexBase);
                }

            }
            public int FamilyLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.FAMILIES, Const.indexBase);
                }

            }
            public int FamilyFinishTypesLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.FAMILYFINISHTYPES, Const.indexBase);
                }

            }
            public int FamilyFinishesLinesNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLinesNb(CatalogEnum.TableId.FAMILYFINISHES, Const.indexBase);
                }

            }
            #endregion

            #region //Number column information
            public int ArticleColumnsNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetColumnsNb(CatalogEnum.TableId.ARTICLES);
                }

            }
            public int PriceColumnsNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetColumnsNb(CatalogEnum.TableId.PRICES);
                }

            }
            public int ReferenceColumnsNb
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetColumnsNb(CatalogEnum.TableId.REFERENCES);
                }

            }
            #endregion

            #region // Get First Line Number
            public int GetModelFinishTypeFirstLineRankFromModelClusterRank(int clusterRank)
            {
                return this.CurrentAppli.Catalog.TableGetFirstLineRankFromClusterRank(CatalogEnum.TableId.MODELFINISHTYPES, clusterRank);
            }
            public int GetModelFinishFirstLineRankFromModelFinishTypeClusterRank(int clusterRank)
            {
                if (Reference._modelsFinishesTypesGetModelFinishFirstLine.Count == 0)
                {
                    Reference._modelsFinishesTypesGetModelFinishFirstLine = this.ModelsFinishesTypes_GetModelFinishFirstLine;
                }
                return Reference._modelsFinishesTypesGetModelFinishFirstLine[clusterRank];
            }
            public int GetHandleFinishFirstLineRankFromModelFinishTypeClusterRank(int clusterRank)
            {
                if (Reference._modelsFinishesTypesGetModelHandleFirstLine.Count == 0)
                {
                    Reference._modelsFinishesTypesGetModelHandleFirstLine = this.ModelsFinishesTypes_GetModelHandleFirstLine;
                }
                return Reference._modelsFinishesTypesGetModelHandleFirstLine[clusterRank];
            }

            #endregion

            #region //Get line information
            public string BlockGetLineInfo(int clusterRank, int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, clusterRank, rank, column);
            }
            public string ArticleGetLineInfo(int clusterRank, int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, clusterRank, rank, column);
            }
            public string ArticleGetLineInfo(int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, Const.indexBase, rank, column);
            }
            public string PriceGetLineInfo(int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.PRICES, Const.indexBase, rank, column);
            }
            public string ReferenceGetLineInfo(int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.PRICES, Const.indexBase, rank, column);
            }
            #endregion

            #region //Get column information
            public string PriceGetColumnTitle(int rank, int column)
            {
                return this.CurrentAppli.Catalog.TableGetColumnTitle(CatalogEnum.TableId.PRICES, Const.indexBase, rank, PriceColumnsNb, column);
            }
            public string PriceGetColumnTitleName(int rank, int column)
            {
                string[] name = this.PriceGetColumnTitle(rank, column).Split(' ');
                if (name.Length > 0)
                {
                    return name[0];
                }
                return String.Empty;
            }
            public string PriceGetColumnTitleCode(int rank, int column)
            {
                string[] name = this.PriceGetColumnTitle(rank, column).Split(' ');
                if (name.Length > 1)
                {
                    return name[1];
                }
                return String.Empty;
            }
            public string PriceGetColumnTitleNumber(int rank, int column)
            {
                string[] name = this.PriceGetColumnTitle(rank, column).Split(' ');
                if (name.Length > 0)
                {
                    return name[name.Length - 1];
                }
                return String.Empty;
            }
            public bool IsPriceTitleContainsModelCode(int rank, int column, string value)
            {
                string[] name = this.PriceGetColumnTitle(rank, column).Split(' ');
                if (name.Length > 0)
                {
                    foreach (string text in name)
                    {
                        if (text.Equals(value))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            #endregion

            #region // Section Table
            public string SectionIndex()
            {
                return this.CurrentAppli.CatalogGetSectionsList(this.CatalogFileName, true, "@i" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string SectionRank()
            {
                return this.CurrentAppli.CatalogGetSectionsList(this.CatalogFileName, true, "@r" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string SectionCode()
            {
                return this.CurrentAppli.CatalogGetSectionsList(this.CatalogFileName, true, "@c" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string SectionName()
            {
                return this.CurrentAppli.CatalogGetSectionsList(this.CatalogFileName, true, "@n" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string Section_Code
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.SECTIONS, Const.indexBase, this.SectionLineIndex, (int)CatalogPropertyEnum.SectionColumn.CODE);
                }
            }
            public string Section_Name
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.SECTIONS, Const.indexBase, this.SectionLineIndex, (int)CatalogPropertyEnum.SectionColumn.NAME);
                }
            }
            public int Section_BlockNb
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.SECTIONS, Const.indexBase, this.SectionLineIndex, (int)CatalogPropertyEnum.SectionColumn.BLOCKNB), 0);
                }
            }
            #endregion

            #region // Block Table
            public string BlockRank(int rank)
            {
                return this.CurrentAppli.CatalogGetBlocksList(this.CatalogFileName, rank, true, "@r" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string Block_Code
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.CODE);
                }
            }
            public string Block_Script
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.SCRIPT);
                }
            }
            public string Block_Name
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.NAME);
                }
            }
            public int Block_ArticleNb
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.REFERENCENB), 0);
                }
            }
            public int Block_PoseOnorUnderIndex
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.POSEONORUNDER), KD.Const.UnknownId);
                }
            }
            public double Block_Altitude
            {
                get
                {
                    return this.GetStringToDouble(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.ALTITUDE), 0);
                }
            }
            public int Block_PricingIndex
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.PRICING), KD.Const.UnknownId);
                }
            }
            public int Block_FamilyIndex
            {
                get
                {
                    return (this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.FAMILY), KD.Const.UnknownId) - Const.valueToBaseIndex);
                }
            }
            public string Block_Description
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.BLOCKS, Const.indexBase, this.BlockLineIndex, (int)CatalogPropertyEnum.BlockColumn.DESCRITPTION);
                }
            }
            #endregion

            #region // Article Table
            public string ArticleRank(int rank)
            {
                return this.CurrentAppli.CatalogGetArticlesList(this.CatalogFileName, rank, true, "@r" + KD.ScriptHelper.VarString.VarStringVariableValueSeparator);
            }
            public string Article_Key
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.KEYREFERENCE);
                }

            }
            public string Article_Hinge
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.HINGE);
                }
            }
            public int Article_Width
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.WIDTH), 1);
                }
            }
            public int Article_Depth
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.DEPTH), 1);
                }
            }
            public int Article_Height
            {
                get
                {
                    return this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.HEIGHT), 1);
                }
            }
            public string Article_CodeKey
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.CODE);
                }
            }
            public string Article_FinishKey
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.FINISH);
                }
            }
            public string Article_EcoMobCode
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.ECOMOBCODE);
                }
            }
            public double Article_EcoMobWeight
            {
                get
                {
                    return this.GetStringToDouble(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.ARTICLES, this.BlockLineIndex, this.ArticleLineIndex, (int)CatalogPropertyEnum.ArticleColumn.ECOMOBWEIGHT), KD.Const.UnknownId);
                }
            }
            #endregion

            #region // Family Table
            public string Family_Code
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.CODE);
                }
            }
            public string Family_Name
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.NAME);
                }
            }
            public bool Family_IsModelFront
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.MODELFRONT) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public bool Family_IsModelCarcasse
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.MODELCARCASSE) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;

                }
            }
            public bool Family_IsModelHandle
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.MODELHANDLE) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public bool Family_IsModelDrawer
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.MODELDRAWER) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public bool Family_IsVisibleSide
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.VISIBLESIDE) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;

                }
            }
            public bool Family_IsGlassType
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.GLASSTYPE) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public bool Family_IsPricePerModel
            {
                get
                {
                    if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.PRICEPERMODEL) == KD.StringTools.Const.One)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public int Family_FinishTypeNb
            {
                get
                {
                    return GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILIES, Const.indexBase, Block_FamilyIndex, (int)CatalogPropertyEnum.FamilyColumn.FINISHTYPESNB), 0);
                }
            }
            #endregion

            #region // Families finishes types Table
            public List<string> FamiliesFinishesTypes_Family
            {
                get
                {
                    List<string> _familiesFinishesTypesFamily = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _familiesFinishesTypesFamily.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.FAMILY));
                    }
                    return _familiesFinishesTypesFamily;
                }
            }
            public List<string> FamiliesFinishesTypes_Name
            {
                get
                {
                    List<string> _familiesFinishesTypesFamilyName = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _familiesFinishesTypesFamilyName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.NAME));
                    }
                    return _familiesFinishesTypesFamilyName;
                }
            }
            public List<int> FamiliesFinishesTypes_TypeNumber
            {
                get
                {
                    List<int> _familiesFinishesTypesFamilyFinishTypeNumber = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _familiesFinishesTypesFamilyFinishTypeNumber.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.TYPENUMBER), KD.Const.UnknownId));
                    }
                    return _familiesFinishesTypesFamilyFinishTypeNumber;
                }
            }
            public List<int> FamiliesFinishesTypes_DefaultChoice
            {
                get
                {
                    List<int> _familiesFinishesTypesFamilyDefaultChoice = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _familiesFinishesTypesFamilyDefaultChoice.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.DEFAULTCHOICE), KD.Const.UnknownId));
                    }
                    return _familiesFinishesTypesFamilyDefaultChoice;
                }
            }
            public List<bool> FamiliesFinishesTypes_IsLink
            {
                get
                {
                    List<bool> _isFamiliesFinishesTypes_FamilyFlagLink = new List<bool>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.FLAGLINK) == KD.StringTools.Const.One)
                        {
                            _isFamiliesFinishesTypes_FamilyFlagLink.Add(true);
                        }
                        else
                        {
                            _isFamiliesFinishesTypes_FamilyFlagLink.Add(false);
                        }
                    }
                    return _isFamiliesFinishesTypes_FamilyFlagLink;
                }
            }
            public List<bool> FamiliesFinishesTypes_IsCodeAddRef
            {
                get
                {
                    List<bool> _isFamiliesFinishesTypes_FamilyFlagFinishCodeAddRef = new List<bool>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.FLAGFINISHCODEADDREFERENCE) == KD.StringTools.Const.One)
                        {
                            _isFamiliesFinishesTypes_FamilyFlagFinishCodeAddRef.Add(true);
                        }
                        else
                        {
                            _isFamiliesFinishesTypes_FamilyFlagFinishCodeAddRef.Add(false);
                        }
                    }
                    return _isFamiliesFinishesTypes_FamilyFlagFinishCodeAddRef;
                }
            }
            public List<int> FamiliesFinishesTypes_Nb
            {
                get
                {
                    List<int> _familiesFinishesTypesFamilyFinishCount = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Family_FinishTypeNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _familiesFinishesTypesFamilyFinishCount.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex, lineIndex,
                            (int)CatalogPropertyEnum.FamilyFinishTypeColumn.FINISHESCOUNT), 0));
                    }
                    return _familiesFinishesTypesFamilyFinishCount;
                }
            }
            #endregion

            #region // Families finishes Table
            private int FinishesTypesIndex
            {
                get
                {
                    return this.CurrentAppli.Catalog.TableGetFirstLineRankFromClusterRank(CatalogEnum.TableId.FAMILYFINISHTYPES, Block_FamilyIndex);
                }
            }

            public List<string> FamiliesFinishes_Family
            {
                get
                {
                    List<string> _familiesFinishesFamily = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesFamily.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.FAMILY));
                        }
                        index += 1;
                    }
                    return _familiesFinishesFamily;
                }
            }
            public List<string> FamiliesFinishes_Type
            {
                get
                {
                    List<string> _familiesFinishesType = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesType.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.FINISHTYPE));
                        }
                        index += 1;
                    }
                    return _familiesFinishesType;
                }
            }
            public List<string> FamiliesFinishes_Code
            {
                get
                {
                    List<string> _familiesFinishesCode = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesCode.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.CODE));
                        }
                        index += 1;
                    }
                    return _familiesFinishesCode;
                }
            }
            public List<string> FamiliesFinishes_Name
            {
                get
                {
                    List<string> _familiesFinishesName = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.NAME));
                        }
                        index += 1;
                    }
                    return _familiesFinishesName;
                }
            }
            public List<int> FamiliesFinishes_Color_1
            {
                get
                {
                    List<int> _familiesFinisheColor_1 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_1.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_1), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_1;
                }
            }
            public List<int> FamiliesFinishes_Color_2
            {
                get
                {
                    List<int> _familiesFinisheColor_2 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_2.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_2), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_2;
                }
            }
            public List<int> FamiliesFinishes_Color_3
            {
                get
                {
                    List<int> _familiesFinisheColor_3 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_3.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_3), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_3;
                }
            }
            public List<int> FamiliesFinishes_Color_4
            {
                get
                {
                    List<int> _familiesFinisheColor_4 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_4.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_4), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_4;
                }
            }
            public List<int> FamiliesFinishes_Color_5
            {
                get
                {
                    List<int> _familiesFinisheColor_5 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_5.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_5), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_5;
                }
            }
            public List<int> FamiliesFinishes_Color_6
            {
                get
                {
                    List<int> _familiesFinisheColor_6 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_6.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_6), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_6;
                }
            }
            public List<int> FamiliesFinishes_Color_7
            {
                get
                {
                    List<int> _familiesFinisheColor_7 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_7.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_7), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_7;
                }
            }
            public List<int> FamiliesFinishes_Color_8
            {
                get
                {
                    List<int> _familiesFinisheColor_8 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinisheColor_8.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.TEXTURECOLORIS_8), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinisheColor_8;
                }
            }
            public List<bool> FamiliesFinishes_IsPricePerArticle
            {
                get
                {
                    List<bool> _familiesFinishesPricePerArticle = new List<bool>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex,
                                (int)CatalogPropertyEnum.FamilylFinishColumn.FLAGPRICEPERARTICLE) == KD.StringTools.Const.One)
                            {
                                _familiesFinishesPricePerArticle.Add(true);
                            }
                            else
                            {
                                _familiesFinishesPricePerArticle.Add(false);
                            }
                        }
                        index += 1;
                    }
                    return _familiesFinishesPricePerArticle;
                }
            }
            public List<decimal> FamiliesFinishes_Price
            {
                get
                {
                    List<decimal> _familiesFinishesPrice = new List<decimal>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesPrice.Add(this.GetStringToDecimal(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.PRICE), 0m));
                        }
                        index += 1;
                    }
                    return _familiesFinishesPrice;
                }
            }
            public List<int> FamiliesFinishes_Pricing
            {
                get
                {
                    List<int> _familiesFinishesPricing = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesPricing.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.PRICING), KD.Const.UnknownId));
                        }
                        index += 1;
                    }
                    return _familiesFinishesPricing;
                }
            }
            public List<bool> FamiliesFinishes_IsAddPrice
            {
                get
                {
                    List<bool> _familiesFinishesAddPrice = new List<bool>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex,
                            (int)CatalogPropertyEnum.FamilylFinishColumn.FLAGADDPRICE) == KD.StringTools.Const.One)
                            {
                                _familiesFinishesAddPrice.Add(true);
                            }
                            else
                            {
                                _familiesFinishesAddPrice.Add(false);
                            }
                        }
                        index += 1;
                    }
                    return _familiesFinishesAddPrice;
                }
            }
            public List<string> FamiliesFinishes_Width
            {
                get
                {
                    List<string> _familiesFinishesWidth = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesWidth.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.WIDTH));
                        }
                        index += 1;
                    }
                    return _familiesFinishesWidth;
                }
            }
            public List<string> FamiliesFinishes_Depth
            {
                get
                {
                    List<string> _familiesFinishesDepth = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesDepth.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.DEPTH));
                        }
                        index += 1;
                    }
                    return _familiesFinishesDepth;
                }
            }
            public List<string> FamiliesFinishes_Height
            {
                get
                {
                    List<string> _familiesFinishesHeight = new List<string>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesHeight.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.HEIGHT));
                        }
                        index += 1;
                    }
                    return _familiesFinishesHeight;
                }
            }
            public List<bool> FamiliesFinishes_IsWoodGrain
            {
                get
                {
                    List<bool> _familiesFinishesWoodGrain = new List<bool>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES, (FinishesTypesIndex + index), lineIndex,
                           (int)CatalogPropertyEnum.FamilylFinishColumn.WOODGRAIN) == KD.StringTools.Const.One)
                            {
                                _familiesFinishesWoodGrain.Add(true);
                            }
                            else
                            {
                                _familiesFinishesWoodGrain.Add(false);
                            }
                        }
                        index += 1;
                    }
                    return _familiesFinishesWoodGrain;
                }
            }
            public List<int> FamiliesFinishes_LinkType1
            {
                get
                {
                    List<int> _familiesFinishesTypeLink1 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesTypeLink1.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.FINISHTYPELINK1), 0));
                        }
                        index += 1;
                    }
                    return _familiesFinishesTypeLink1;
                }
            }
            public List<int> FamiliesFinishes_LinkType2
            {
                get
                {
                    List<int> _familiesFinishesTypeLink2 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesTypeLink2.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.FINISHTYPELINK2), 0));
                        }
                        index += 1;
                    }
                    return _familiesFinishesTypeLink2;
                }
            }
            public List<int> FamiliesFinishes_LinkType3
            {
                get
                {
                    List<int> _familiesFinishesTypeLink3 = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesTypeLink3.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.FINISHTYPELINK3), 0));
                        }
                        index += 1;
                    }
                    return _familiesFinishesTypeLink3;
                }
            }
            public List<int> FamiliesFinishes_SpecialType
            {
                get
                {
                    List<int> _familiesFinishesType = new List<int>();
                    int index = 0;
                    foreach (int list in FamiliesFinishesTypes_Nb)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (list - Const.valueToBaseIndex); lineIndex++)
                        {
                            _familiesFinishesType.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.FAMILYFINISHES,
                                (FinishesTypesIndex + index), lineIndex, (int)CatalogPropertyEnum.FamilylFinishColumn.SPECIALTYPE), 0));
                        }
                        index += 1;
                    }
                    return _familiesFinishesType;
                }
            }
            #endregion

            #region // Models Table
            public List<string> Models_Code
            {
                get
                {
                    List<string> _modelsCode = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsCode.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.CODE));
                    }
                    return _modelsCode;
                }
            }
            public List<int> Models_PriceGroup
            {
                get
                {
                    List<int> _modelsPriceGroup = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsPriceGroup.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.PRICEGROUP), 0));
                    }
                    return _modelsPriceGroup;
                }
            }
            public List<string> Models_Name
            {
                get
                {
                    List<string> _modelsName = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.NAME));
                    }
                    return _modelsName;
                }
            }
            public List<string> Models_Script
            {
                get
                {
                    List<string> _modelsScript = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsScript.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.SCRIPT));
                    }
                    return _modelsScript;
                }
            }
            public List<string> Models_Description
            {
                get
                {
                    List<string> _modelsDescription = new List<string>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsDescription.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.DESCRIPTION));
                    }
                    return _modelsDescription;
                }
            }
            public List<int> Models_FinishTypesNb
            {
                get
                {
                    List<int> _modelsFinishTypesNb = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsFinishTypesNb.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.FINISHTYPESNB), 0));
                    }
                    return _modelsFinishTypesNb;
                }
            }
            public List<int> Models_UseModelPrices
            {
                get
                {
                    List<int> _modelsUseModelPrices = new List<int>();
                    for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (ModelLinesNb - Const.valueToBaseIndex); lineIndex++)
                    {
                        _modelsUseModelPrices.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELS, Const.indexBase, lineIndex, (int)CatalogPropertyEnum.ModelColumn.USEMODELPRICES), 0));
                    }
                    return _modelsUseModelPrices;
                }
            }
            #endregion

            #region // Models finishes types Table
            public List<string> ModelsFinishesTypes_Model
            {
                get
                {
                    List<string> _modelsFinishesTypesModel = new List<string>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            _modelsFinishesTypesModel.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.MODEL));
                        }
                    }
                    return _modelsFinishesTypesModel;
                }
            }
            public List<string> ModelsFinishesTypes_Name
            {
                get
                {
                    List<string> _modelsFinishesTypesName = new List<string>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            _modelsFinishesTypesName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.NAME));
                        }
                    }
                    return _modelsFinishesTypesName;
                }
            }
            public List<int> ModelsFinishesTypes_TypeNumber
            {
                get
                {
                    List<int> _modelsFinishesTypesNumber = new List<int>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            _modelsFinishesTypesNumber.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.TYPENUMBER), KD.Const.UnknownId));
                        }
                    }
                    return _modelsFinishesTypesNumber;
                }
            }
            public List<string> ModelsFinishesTypes_DefaultChoice
            {
                get
                {
                    List<string> _modelsFinishesDefaultChoice = new List<string>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            _modelsFinishesDefaultChoice.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.DEFAULTCHOICE));
                        }
                    }
                    return _modelsFinishesDefaultChoice;
                }
            }
            public List<bool> ModelsFinishesTypes_IsLink
            {
                get
                {
                    List<bool> _modelsFinishesTypes_IsLink = new List<bool>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            if (this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.FLAGLINK) == KD.StringTools.Const.One)
                            {
                                _modelsFinishesTypes_IsLink.Add(true);
                            }
                            else
                            {
                                _modelsFinishesTypes_IsLink.Add(false);
                            }
                        }
                    }
                    return _modelsFinishesTypes_IsLink;
                }
            }
            public List<int> ModelsFinishesTypes_Nb
            {
                get
                {
                    List<int> _modelsFinishesTypesNb = new List<int>();
                    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
                    {
                        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
                        {
                            _modelsFinishesTypesNb.Add(this.GetStringToInt(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
                                (int)CatalogPropertyEnum.ModelFinishTypeColumn.FINISHESNB), 0));
                        }
                    }
                    return _modelsFinishesTypesNb;
                }
            }

            public List<int> ModelsFinishesTypes_GetModelFinishFirstLine
            {
                get
                {
                    Reference._modelsFinishesTypesGetModelFinishFirstLine.Clear();
                    int cluster = 0;
                    this.HandleTypeNumberToDispathTableList();

                    for (int rank = 0; rank <= this.ModelsFinishesTypes_TypeNumber.Count - 1; rank++)
                    {
                        Reference._modelsFinishesTypesGetModelFinishFirstLine.Add(cluster);

                        if (!_handleTypeNumberToDispatchTableList.Contains(this.ModelsFinishesTypes_TypeNumber[rank]))
                        {
                            cluster += this.ModelsFinishesTypes_Nb[rank];
                        }
                    }
                    return Reference._modelsFinishesTypesGetModelFinishFirstLine;
                }
            }
            public List<int> ModelsFinishesTypes_GetModelHandleFirstLine
            {
                get
                {
                    Reference._modelsFinishesTypesGetModelHandleFirstLine.Clear();
                    int cluster = 0;
                    this.HandleTypeNumberToDispathTableList();

                    for (int rank = 0; rank <= this.ModelsFinishesTypes_TypeNumber.Count - 1; rank++)
                    {
                        Reference._modelsFinishesTypesGetModelHandleFirstLine.Add(cluster);
                        if (_handleTypeNumberToDispatchTableList.Contains(this.ModelsFinishesTypes_TypeNumber[rank]))
                        {
                            cluster += this.ModelsFinishesTypes_Nb[rank];
                        }
                    }
                    return Reference._modelsFinishesTypesGetModelHandleFirstLine;
                }
            }

            #endregion

            #region // Models finishes Table
            //private int ModelsTypesIndex
            //{
            //    get
            //    {
            //        return this.CurrentAppli.Catalog.TableGetFirstLineRankFromClusterRank(CatalogEnum.TableId.MODELFINISHTYPES, Block_FamilyIndex);
            //    }
            //}

            //int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;

            public List<string> ModelsFinishes_Code
            {
                get
                {
                    List<string> _modelsFinishesCode = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesCode.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.CODE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesCode;
                }
            }
            public List<string> ModelsFinishes_Name
            {
                get
                {
                    List<string> _modelsFinishesName = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.NAME));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesName;
                }
            }
            public List<string> ModelsFinishes_Texture1
            {
                get
                {
                    List<string> _modelsFinishesTexture1 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture1.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture1;
                }
            }
            public List<string> ModelsFinishes_Texture2
            {
                get
                {
                    List<string> _modelsFinishesTexture2 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture2.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture2;
                }
            }
            public List<string> ModelsFinishes_Texture3
            {
                get
                {
                    List<string> _modelsFinishesTexture3 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture3.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture3;
                }
            }
            public List<string> ModelsFinishes_Texture4
            {
                get
                {
                    List<string> _modelsFinishesTexture4 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture4.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture4;
                }
            }
            public List<string> ModelsFinishes_Texture5
            {
                get
                {
                    List<string> _modelsFinishesTexture5 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture5.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture5;
                }
            }
            public List<string> ModelsFinishes_Texture6
            {
                get
                {
                    List<string> _modelsFinishesTexture6 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture6.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture6;
                }
            }
            public List<string> ModelsFinishes_Texture7
            {
                get
                {
                    List<string> _modelsFinishesTexture7 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture7.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture7;
                }
            }
            public List<string> ModelsFinishes_Texture8
            {
                get
                {
                    List<string> _modelsFinishesTexture8 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesTexture8.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesTexture8;
                }
            }
            public List<string> ModelsFinishes_PricePerArticle
            {
                get
                {
                    List<string> _modelsFinishesPricePerArticle = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesPricePerArticle.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.FLAGPRICEPERARTICLE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesPricePerArticle;
                }
            }
            public List<string> ModelsFinishes_Price
            {
                get
                {
                    List<string> _modelsFinishesPrice = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesPrice.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.PRICE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesPrice;
                }
            }
            public List<string> ModelsFinishes_Pricing
            {
                get
                {
                    List<string> _modelsFinishesPricing = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesPricing.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.PRICING));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesPricing;
                }
            }
            public List<string> ModelsFinishes_Add
            {
                get
                {
                    List<string> _modelsFinishesAdd = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesAdd.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.FLAGADDPRICE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesAdd;
                }
            }
            public List<string> ModelsFinishes_Wooden
            {
                get
                {
                    List<string> _modelsFinishesWooden = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesWooden.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.WOOD));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesWooden;
                }
            }
            public List<string> ModelsFinishes_Link1
            {
                get
                {
                    List<string> _modelsFinishesLink1 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesLink1.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.LINK1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesLink1;
                }
            }
            public List<string> ModelsFinishes_Link2
            {
                get
                {
                    List<string> _modelsFinishesLink2 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesLink2.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.LINK2));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesLink2;
                }
            }
            public List<string> ModelsFinishes_Link3
            {
                get
                {
                    List<string> _modelsFinishesLink3 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesLink3.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.LINK3));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesLink3;
                }
            }
            public List<string> ModelsFinishes_Type
            {
                get
                {
                    List<string> _modelsFinishesLink3 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (!_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsFinishesLink3.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelFinishColumn.TYPE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsFinishesLink3;
                }
            }
            #endregion

            #region // Models handles Table
            public List<string> ModelsHandles_Code
            {
                get
                {
                    List<string> _modelsHandlesCode = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesCode.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.CODE));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesCode;
                }
            }
            public List<string> ModelsHandles_Name
            {
                get
                {
                    List<string> _modelsHandlesName = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.NAME));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesName;
                }
            }
            public List<string> ModelsHandles_Drawing
            {
                get
                {
                    List<string> _modelsHandlesDraw = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesDraw.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.DRAWING));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesDraw;
                }
            }
            public List<string> ModelsHandles_Texture1
            {
                get
                {
                    List<string> _modelsHandlesTexture1 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesTexture1.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesTexture1;
                }
            }
            public List<string> ModelsHandles_Texture2
            {
                get
                {
                    List<string> _modelsHandlesTexture2 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesTexture2.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.TEXTURECOLORIS_1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesTexture2;
                }
            }
            public List<string> ModelsHandles_Link1
            {
                get
                {
                    List<string> _modelsHandlesLink1 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesLink1.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.LINK1));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesLink1;
                }
            }
            public List<string> ModelsHandles_Link2
            {
                get
                {
                    List<string> _modelsHandlesLink2 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesLink2.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.LINK2));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesLink2;
                }
            }
            public List<string> ModelsHandles_Link3
            {
                get
                {
                    List<string> _modelsHandlesLink3 = new List<string>();
                    this.HandleTypeNumberToDispathTableList();
                    int modelsFinishesTypesNbCount = ModelsFinishesTypes_Nb.Count;
                    List<int> modelsFinishesTypesTypeNumber = ModelsFinishesTypes_TypeNumber;
                    List<int> modelsFinishesTypesNbNb = ModelsFinishesTypes_Nb;
                    int clusterIndex = 0;
                    for (int index = (1 - Const.valueToBaseIndex); index <= (modelsFinishesTypesNbCount - Const.valueToBaseIndex); index++)
                    {
                        if (_handleTypeNumberToDispatchTableList.Contains(modelsFinishesTypesTypeNumber[index]))
                        {
                            for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (modelsFinishesTypesNbNb[index] - Const.valueToBaseIndex); lineIndex++)
                            {
                                _modelsHandlesLink3.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELHANDLES, clusterIndex, lineIndex,
                                    (int)CatalogPropertyEnum.ModelHandleColumn.LINK3));
                            }
                            clusterIndex += 1;
                        }
                    }
                    return _modelsHandlesLink3;
                }
            }
            #endregion
            #endregion // Properties



            #region // Methods

            //List Information
            public string BlocksList(int sectionRank)
            {
                string data = this.CurrentAppli.CatalogGetBlocksList(CatalogFileName, sectionRank, true, "@n" + KD.CharTools.Const.Pipe);
                if (data.Length > 0)
                {
                    return data.Substring(0, data.Length - 1);
                }
                return string.Empty;
            }
            public List<string> BlocksList()
            {
                List<string> list = new List<string>();
                if (this.IsComplementaryCatalog())
                {
                    for (int sectionRank = 0; sectionRank < SectionLinesNb; sectionRank++)
                    {
                        string data = this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.COMPLEMENTARYCAT, Const.indexBase, sectionRank, (int)CatalogPropertyEnum.ComplementaryColumn.BLOCKNAME);
                        if (!string.IsNullOrEmpty(data))
                        {
                            list.Add(data);
                        }
                    }
                }
                else
                {
                    for (int sectionRank = 0; sectionRank < SectionLinesNb; sectionRank++)
                    {
                        string data = BlocksList(sectionRank);
                        if (!string.IsNullOrEmpty(data))
                        {
                            list.Add(BlocksList(sectionRank));
                        }
                    }
                }
                return list;
            }

            public int GetHinge()
            {
                if (this.Article_Hinge == this.CurrentAppli.GetTranslatedText("G"))
                {
                    return 1;
                }
                else if (this.Article_Hinge == this.CurrentAppli.GetTranslatedText("D"))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }

            private int GetStringToInt(string value, int returnValue)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return System.Convert.ToInt32(value);
                }
                return returnValue;
            }
            private double GetStringToDouble(string value, double returnValue)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return System.Convert.ToDouble(value);
                }
                return returnValue;
            }
            private decimal GetStringToDecimal(string value, decimal returnValue)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return System.Convert.ToDecimal(value);
                }
                return returnValue;
            }

            //List<string> _firstModelsFinishesTypesName = new List<string>();
            //private void ModelsFinishesTypesName()
            //{                
            //    for (int modelLineIndex = (1 - Const.valueToBaseIndex); modelLineIndex <= (ModelLinesNb - Const.valueToBaseIndex); modelLineIndex++)
            //    {
            //        for (int lineIndex = (1 - Const.valueToBaseIndex); lineIndex <= (Models_FinishTypesNb[modelLineIndex] - Const.valueToBaseIndex); lineIndex++)
            //        {
            //            _firstModelsFinishesTypesName.Add(this.CurrentAppli.Catalog.TableGetLineInfo(CatalogEnum.TableId.MODELFINISHTYPES, modelLineIndex, lineIndex,
            //                (int)CatalogPropertyEnum.ModelFinishTypeColumn.name));
            //        }
            //    }                   
            //}

            public void HandleTypeNumberToDispathTableList()
            {
                if (_handleTypeNumberToDispatchTableList.Count == 0)
                {
                    int[] input = { 5, 151, 24, 25, 31, 32 };
                    _handleTypeNumberToDispatchTableList.AddRange(input);
                }
            }

            #endregion // Methods

            //
            public int GetArticleLineIndexFromReference(string referenceKey)
            {              
                return (this.CurrentAppli.Catalog.TableGetLineRankFromName(SDK.CatalogEnum.TableId.ARTICLES, Const.indexBase, Const.firstLine, referenceKey, false));
            }
            public int GetBlockLineIndexFromReference(string referenceKey)
            {
                return (this.CurrentAppli.Catalog.TableGetClusterRankFromLineRank(SDK.CatalogEnum.TableId.ARTICLES, this.GetArticleLineIndexFromReference(referenceKey))); ;
            }

            public string GetConstantValueFromTableConstants(int lineRank)
            {
                return (this.CurrentAppli.Catalog.TableGetLineInfo(SDK.CatalogEnum.TableId.CONSTANTS, 0, lineRank, 2));
            }
            public int GetLineRankByCodeFromTableConstants(string code)
            {
                return (this.CurrentAppli.Catalog.TableGetLineRankFromCode(SDK.CatalogEnum.TableId.CONSTANTS, 0, 0, code, false));
            }

            public string GetConstantFromCat(string str)
            {
                if (str.StartsWith(Const.characterC.ToString()))
                {                   
                    str = this.GetConstantValueFromTableConstants(this.GetLineRankByCodeFromTableConstants(str.Substring(1)));
                }
                return str;
            }

            public string GetConstantValueFromScript(string str)
            {
                if (str.StartsWith(Const.characterC.ToString()) && this.Block_Script.Contains(str))
                {
                    string[] data = this.GetScriptSplit();
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        if (data[i].ToUpper() == str.ToUpper())
                        {
                            return data[i + 1];
                        }
                    }
                }
                return String.Empty;
            }
          
            public string[] GetScriptSplit()
            {
                return (this.Block_Script.Split(new Char[] { '\"', '=', ',', ')' })); //KD.CharTools.Const.BackSlatch});
            }
          
            public string SetConstantInVarToScript(string searchText, int constant)
            {
                string script = this.Block_Script;
                if (!String.IsNullOrEmpty(script) && script.Contains(Const.Var.ToUpper()))
                {
                    int ind = 0;
                    int len = 0;
                    string[] data = this.GetScriptSplit();
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        ind += data[i].Length + 1;
                        if (data[i].ToUpper() == searchText.ToUpper())
                        {
                            if (data[i - 1].ToUpper() == Const.Var.ToUpper() || data[i - 1].ToUpper() == StringTools.Const.WhiteSpace + Const.Var.ToUpper())
                            {
                                len = data[i + 2].Length;
                                break;
                            }
                        }
                    }

                    int lenScript = script.Length;
                    if (ind < script.Length && len > 0)
                    {
                        script = script.Remove(ind + 1, len);
                        script = script.Insert(ind + 1, constant.ToString());
                    }
                }
                return script;
            }

            public string SetConstantToScript(string searchText, int constant)
            {
                string script = this.Block_Script;
                if (!String.IsNullOrEmpty(script))
                {
                    int ind = 0;
                    int len = 0;
                    string[] data = this.GetScriptSplit();
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        ind += data[i].Length + 1;
                        if (data[i].ToUpper() == searchText.ToUpper())
                        {                          
                            len = data[i + 1].Length;
                            break;                           
                        }
                    }

                    int lenScript = script.Length;
                    if (ind < script.Length && len > 0)
                    {
                        script = script.Remove(ind, len);
                        script = script.Insert(ind, constant.ToString());
                    }
                }
                
                return script;
            }
         
        }

        public class Const
        {            
            public const int indexBase = -1;
            public const int firstLine = 0;
            public const string catalogExtension = ".cat";
            public const string catalogsDir = "CatalogsDir";
            public const string arobase = "@";
            public const string Var = "@VAR(";
            public const int valueToBaseIndex = 1; //value to retrieve the base 0 (zero). Else put the value to 0 for retrieve the index line begin to 1 (one).

            public static char characterC = Convert.ToChar(67);           
        }

        public class ModelFinishTypeName
        {
            public const string FRONTCOLOR = "Coloris façade";
            public const string CARCASSECOLOR = "Coloris caisson";
        }

        public class CatalogPropertyEnum
        {
            public CatalogPropertyEnum() { }

            public enum ConstanteColumn
            {
                NUMBER = 0,
                NAME = 1,
                VALUE = 2,
                BASEVALUE = 3,
            }
            public enum SectionColumn
            {
                CODE = 0,
                NAME = 1,
                BLOCKNB = 2,
            }
            public enum BlockColumn
            {
                CODE = 0,
                SCRIPT = 1,
                NAME = 2,
                REFERENCENB = 3,
                POSEONORUNDER = 4,
                ALTITUDE = 5,
                PRICING = 6,
                FAMILY = 7,
                DESCRITPTION = 8,
            }
            public enum ArticleColumn
            {
                KEYREFERENCE = 0,
                HINGE = 1,
                WIDTH = 2,
                DEPTH = 3,
                HEIGHT = 4,
                CODE = 5,
                FINISH = 6,
                ECOMOBCODE = 7,
                ECOMOBWEIGHT = 8,
            }
            public enum PriceColumn
            {
                KEYREFERENCE = 0,
                HINGE = 1,
                PRICE = 2,
            }
            public enum PurchasePriceColumn
            {
                //keyReference = 0,
                //hinge = 1,
            }
            public enum ReferenceColumn
            {
                KEYREFERENCE = 0,
                HINGE = 1,
            }
            public enum TextureColumn
            {
                CODE = 0,
                NAME = 1,
                COLOR = 2,
                FILE = 3,
                WIDTH = 4,
                HEIGHT = 5,
                //...
            }
            public enum ModelColumn
            {
                CODE = 0,
                PRICEGROUP = 1,
                NAME = 2,
                SCRIPT = 3,
                DESCRIPTION = 4,
                FINISHTYPESNB = 5,
                USEMODELPRICES = 6,
            }
            public enum ModelFinishTypeColumn
            {
                MODEL = 0,
                NAME = 1,
                TYPENUMBER = 2,
                DEFAULTCHOICE = 3,
                FLAGLINK = 4,
                FINISHESNB = 5,
            }
            public enum ModelFinishColumn
            {
                MODEL = 0,
                FINISHTYPE = 1,
                CODE = 2,
                NAME = 3,
                TEXTURECOLORIS_1 = 4,
                TEXTURECOLORIS_2 = 5,
                TEXTURECOLORIS_3 = 6,
                TEXTURECOLORIS_4 = 7,
                TEXTURECOLORIS_5 = 8,
                TEXTURECOLORIS_6 = 9,
                TEXTURECOLORIS_7 = 10,
                TEXTURECOLORIS_8 = 11,
                FLAGPRICEPERARTICLE = 12,
                PRICE = 14,
                PRICING = 15,
                FLAGADDPRICE = 16,
                WOOD = 17,
                LINK1 = 18,
                LINK2 = 19,
                LINK3 = 20,
                TYPE = 21,
            }
            public enum ModelHandleColumn
            {
                MODEL = 0,
                FINISHTYPE = 1,
                CODE = 2,
                NAME = 3,
                DRAWING = 4,
                WIDTH = 5,
                HEIGHT = 6,
                TEXTURECOLORIS_1 = 7,
                TEXTURECOLORIS_2 = 8,
                //FLAGVERTICAL = 9,
                //FLAGHORIZONTAL_CENTER = 10,
                //FLAGVERTICAL_CENTER = 11,
                //FLAGPRICEPERARTICLE = 12,
                //PRICE = 13,
                //PRICING = 14,
                //FRONT = 15,
                //LIE = 16,
                LINK1 = 18,
                LINK2 = 19,
                LINK3 = 20
                //...
            }
            public enum FamilyColumn
            {
                CODE = 0,
                NAME = 1,
                MODELFRONT = 2,
                MODELCARCASSE = 3,
                MODELHANDLE = 4,
                MODELDRAWER = 5,
                VISIBLESIDE = 6,
                GLASSTYPE = 7,
                PRICEPERMODEL = 8,
                FINISHTYPESNB = 9,
            }
            public enum FamilyFinishTypeColumn
            {
                FAMILY = 0,
                NAME = 1,
                TYPENUMBER = 2,
                DEFAULTCHOICE = 3,
                FLAGLINK = 4,
                FLAGFINISHCODEADDREFERENCE = 5,
                FINISHESCOUNT = 6,
            }
            public enum FamilylFinishColumn
            {
                FAMILY = 0,
                FINISHTYPE = 1,
                CODE = 2,
                NAME = 3,
                TEXTURECOLORIS_1 = 4,
                TEXTURECOLORIS_2 = 5,
                TEXTURECOLORIS_3 = 6,
                TEXTURECOLORIS_4 = 7,
                TEXTURECOLORIS_5 = 8,
                TEXTURECOLORIS_6 = 9,
                TEXTURECOLORIS_7 = 10,
                TEXTURECOLORIS_8 = 11,
                FLAGPRICEPERARTICLE = 12,
                PRICE = 14,
                PRICING = 15,
                FLAGADDPRICE = 16,
                WIDTH = 17,
                DEPTH = 18,
                HEIGHT = 19,
                WOODGRAIN = 20,
                FINISHTYPELINK1 = 21,
                FINISHTYPELINK2 = 22,
                FINISHTYPELINK3 = 23,
                SPECIALTYPE = 24,
            }
            public enum Entity2DColumn
            {
                NAME = 0,
                WIDTH = 1,
                DEPTH = 2,
                PRIMITIVENB = 3,
            }
            public enum Primitive2DColumn
            {

            }
            public enum Entity3DColumn
            {
                NAME = 0,
                WIDTH = 1,
                DEPTH = 2,
                HEIGHT = 3,
                //...
                PRIMITIVENB = 11,
            }
            public enum Primitive3DColumn
            {

            }
            public enum ResourceColumn
            {

            }
            public enum ApplicatColumn
            {

            }
            public enum ApplicatControlColumn
            {

            }
            public enum ApplicatRuleColumn
            {

            }
            public enum ApplicatDataTypeColumn
            {

            }
            public enum ApplicatDataColumn
            {

            }
            public enum ComplementaryColumn
            {
                SECTION = 0,
                BLOCKNAME = 1,
                //NAME = 2,
                //REFERENCENB = 3,
                //POSEONORUNDER = 4,
                //ALTITUDE = 5,
                //PRICING = 6,
                //FAMILY = 7,
                //DESCRITPTION = 8,
            }

            public enum ModelFinishTypeTypeNumber
            {

            }
        }
    }
}
